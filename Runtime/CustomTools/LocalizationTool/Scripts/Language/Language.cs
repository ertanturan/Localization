using UnityEngine;

[CreateAssetMenu(
    fileName = "New Language",
    menuName = "Localization/Language")]
public class Language : ScriptableObject
{
    public Alphabet Alphabet;

    public string Name;

    public Sprite Icon;

    public SystemLanguage systemLanguageType;
}
