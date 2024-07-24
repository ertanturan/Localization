using UnityEngine;
using TMPro;

public class LanguageText : TextComponent
{
    private TextAlignmentOptions _latinAlignment;

    [SerializeField] private LanguageDependentText _langDependentText;

    private bool _initialized;

    protected override void Start()
    {
        base.Start();
        Init();
    }

    private void Init()
    {
        if (_initialized) return;
        _initialized = true;
        if (TextPro)
        {
            _latinAlignment = TextPro.alignment;
        }

        if (_langDependentText != null) SetText(LanguageManager.GetText(_langDependentText));

        LanguageManager.OnLanguageChange += SetupLanguage;
    }

    private void SetupLanguage(LanguageChangeEventArgs args)
    {
        if (args.Font != TextPro.font)
        {
            TextPro.font = args.Font;
        }

        if (this && gameObject && _langDependentText != null) SetMultiLanguageText();
    }

    public void SetMultiLanguageText()
    {
        if (TextPro) TextPro.alignment = GetAlignment(LanguageManager.SelectedLanguage.Alphabet);
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