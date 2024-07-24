using UnityEngine;
using TMPro;

public class LanguageText : TextComponent
{
    private TextAlignmentOptions _latinAlignment;

    [SerializeField] private LanguageDependentText _langDependentText;

    protected override void Init()
    {
        base.Init();
        if (RtlText)
        {
            _latinAlignment = RtlText.alignment;
        }

        if (_langDependentText != null) SetText(LanguageManager.GetText(_langDependentText));

        LanguageManager.OnLanguageChange += SetupLanguage;
    }

    private void SetupLanguage(LanguageChangeEventArgs args)
    {
        if (args.Font != RtlText.font)
        {
            RtlText.font = args.Font;
        }

        if (this && gameObject && _langDependentText != null) SetMultiLanguageText();
    }

    public void SetMultiLanguageText()
    {
        if (RtlText) RtlText.alignment = GetAlignment(LanguageManager.SelectedLanguage.Alphabet);
        if (_langDependentText != null) SetText(LanguageManager.GetText(_langDependentText));
    }

    private TextAlignmentOptions GetAlignment(Alphabet alphabet)
    {
        if (alphabet.ReadOrder == ReadOrder.LTR) return _latinAlignment;
        //RTL
        if (_latinAlignment == TextAlignmentOptions.Center ||
            _latinAlignment == TextAlignmentOptions.CenterGeoAligned ||
            _latinAlignment == TextAlignmentOptions.Top ||
            _latinAlignment == TextAlignmentOptions.Bottom)
        {
            return _latinAlignment;
        }

        if (_latinAlignment == TextAlignmentOptions.Right
            || _latinAlignment == TextAlignmentOptions.Left)
        {
            return TextAlignmentOptions.Right;
        }

        if (_latinAlignment == TextAlignmentOptions.BottomRight
            || _latinAlignment == TextAlignmentOptions.BottomLeft)
        {
            return TextAlignmentOptions.BottomRight;
        }

        if (_latinAlignment == TextAlignmentOptions.TopRight
            || _latinAlignment == TextAlignmentOptions.TopLeft)
        {
            return TextAlignmentOptions.TopRight;
        }

        return _latinAlignment;
    }
}