using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class LanguageChangeEventArgs : EventArgs
{
    public Language Language { get; private set; }
    public TMP_FontAsset Font { get; private set; }

    public LanguageChangeEventArgs(Language language, TMP_FontAsset font)
    {
        Language = language;
        Font = font;
    }
}

public static class LanguageManager
{
    private static readonly Dictionary<SystemLanguage, Language> _LanguageDictionary = new();

    public static Language SelectedLanguage { get; private set; }

    private static SystemLanguage _SelectedSystemLanguage { get; set; }

    public static event Action<LanguageChangeEventArgs> OnLanguageChange;

    private static SystemLanguage _DefaultLanguage = SystemLanguage.English;

    [RuntimeInitializeOnLoadMethod]
    private static void Initialize()
    {
        List<Language> supportedLanguages = new(Resources.LoadAll<Language>("Data/Localization/Languages"));

        foreach (Language lang in supportedLanguages)
        {
            _LanguageDictionary.Add(lang.systemLanguageType, lang);
        }

        if (supportedLanguages.Any(x => x.systemLanguageType == Application.systemLanguage))
        {
            SetDefaultLanguage(Application.systemLanguage);
        }
        else
        {
            SetDefaultLanguage(_DefaultLanguage);
        }
    }

    public static void ToggleLanguage()
    {
        for (int i = 0; i < _LanguageDictionary.Count; i++)
        {
            if (_SelectedSystemLanguage == _LanguageDictionary.ElementAt(i).Key)
            {
                if (i != _LanguageDictionary.Count - 1)
                {
                    SetDefaultLanguage(_LanguageDictionary.ElementAt(i + 1).Key);
                }
                else
                {
                    SetDefaultLanguage(_LanguageDictionary.ElementAt(0).Key);
                }

                break;
            }
        }
        LanguageChangeEventArgs eventArgs = new(SelectedLanguage,SelectedLanguage.LanguageFontAsset);
        OnLanguageChange?.Invoke(eventArgs);
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
        if (_LanguageDictionary.TryGetValue(lang, out var selectedLanguage))
        {
            SelectedLanguage = selectedLanguage;
            _DefaultLanguage = lang;
            _SelectedSystemLanguage = lang;
        }
        else
        {
            Debug.Log("Dictionary does not contain this language switching to English...");
            SelectedLanguage = _LanguageDictionary[SystemLanguage.English];
            _DefaultLanguage = SystemLanguage.English;
            _SelectedSystemLanguage = SystemLanguage.English;
        }
    }
}