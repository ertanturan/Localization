using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[Serializable]
public struct AlphabetFont
{
    public Alphabet Alphabet;
    public TMP_FontAsset Font;
}
//we only need one matrix
// [CreateAssetMenu(
//     fileName = "New AlphabetFontMatrix",
//     menuName = "Localization/AlphabetFontMatrix",
//     order = 2)]
public class AlphabetFontMatrix : ScriptableObject
{
    public AlphabetFont[] FontColumns;

    public TMP_FontAsset GetFont(Language language)
    {
        foreach (var alphabetFont in FontColumns)
        {
            if (alphabetFont.Alphabet == language.Alphabet)
            {
                return alphabetFont.Font;
            }
        }

        return null;
    }
}