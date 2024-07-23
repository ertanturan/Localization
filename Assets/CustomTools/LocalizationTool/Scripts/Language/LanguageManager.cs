using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Video;

public static class LanguageManager
{
    private static Dictionary<SystemLanguage, Language> _languageDictionary = new();

    public static AlphabetFontMatrix AlphabetFontMatrix { get; private set; }

    public static Language SelectedLanguage { get; private set; }

    private static SystemLanguage SelectedSystemLanguage { get; set; }

    public static event Action<Language> OnLanguageChange;

    private static SystemLanguage _defaultLanguage = SystemLanguage.English;


    [RuntimeInitializeOnLoadMethod]
    private static void OnLoad()
    {
        List<Language> supportedLanguages = new List<Language>(
            Resources.LoadAll<Language>("Data/Localization/Languages"));

        foreach (Language lang in supportedLanguages)
        {
            _languageDictionary.Add(lang.systemLanguageType, lang);
        }

        AlphabetFontMatrix = Resources.Load<AlphabetFontMatrix>("Data/Localization/AlphabetFontMatrix");
        if (supportedLanguages.Any(x => x.systemLanguageType == Application.systemLanguage))
        {
            SetDefaultLanguage(Application.systemLanguage);
        }
        else
        {
            SetDefaultLanguage(_defaultLanguage);
        }
    }

    public static void ToggleLanguage()
    {
        for (int i = 0; i < _languageDictionary.Count; i++)
        {
            if (SelectedSystemLanguage == _languageDictionary.ElementAt(i).Key)
            {
                if (i != _languageDictionary.Count - 1)
                {
                    SetDefaultLanguage(_languageDictionary.ElementAt(i + 1).Key);
                }
                else
                {
                    SetDefaultLanguage(_languageDictionary.ElementAt(0).Key);
                }

                break;
            }
        }

        OnLanguageChange.Invoke(_languageDictionary[SelectedSystemLanguage]);
    }

    public static string GetText(LanguageDependentText text, params object[] args)
    {
        return string.Format(text.GetString(SelectedLanguage), args);
    }

    public static Sprite GetSprite(LanguageDependentSprite sprite)
    {
        return sprite.GetSprite(SelectedLanguage);
    }

    public static VideoClip GetVideoClip(LanguageDependentVideo videoClip)
    {
        return videoClip.GetVideoClip(SelectedLanguage);
    }

    private static void SetDefaultLanguage(SystemLanguage lang)
    {
        if (_languageDictionary.ContainsKey(lang))
        {
            SelectedLanguage = _languageDictionary[lang];
            _defaultLanguage = _languageDictionary[lang];
            SelectedSystemLanguage = lang;
        }
        else
        {
            Debug.Log("Dictionary does not contain this language switching to English...");
            SelectedLanguage = _languageDictionary[SystemLanguage.English];
            _defaultLanguage = _languageDictionary[SystemLanguage.English];
            SelectedSystemLanguage = SystemLanguage.English;
        }
    }
}