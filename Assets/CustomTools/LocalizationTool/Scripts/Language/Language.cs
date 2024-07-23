using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

[CreateAssetMenu(
    fileName = "New Language",
    menuName = "Localization/Language",
    order = 2)]
public class Language : ScriptableObject
{
    public Alphabet Alphabet;

    public string Name;

    public Sprite Icon;

    public SystemLanguage systemLanguageType;

    public bool UseAssignedFont;

    public TMP_FontAsset Font;
}