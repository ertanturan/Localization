using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct LanguageTextTuple
{
    public Language Language;
    [TextArea]
    public string Text;
}
[CreateAssetMenu(
    fileName = "New Language Dependent Text",
    menuName = "Localization/Language Dependent Text",
    order = 1)]
public class LanguageDependentText : ScriptableObject
{
    public LanguageTextTuple[] texts;

    private Dictionary<Language, string> _dictionary;

    private Dictionary<Language, string> Dictionary
    {
        get
        {
            if (_dictionary == null)
            {
                _dictionary = new Dictionary<Language, string>();
                foreach (var item in texts)
                {
                    if (item.Language == null)
                        Debug.LogError("Language empty for Language Dependent Text: " + this);
                    else
                        _dictionary[item.Language] = "" + item.Text;
                }
            }
            return _dictionary;
        }
    }

    public string GetString(Language language)
    {
        return Dictionary[language];
    }
}
