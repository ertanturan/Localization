using UnityEngine;
using UnityEngine.UI;

public class LanguageButton : ButtonComponent
{
    public override Button _button { get; set; }

    public override void Awake()
    {
        base.Awake();
    }

    public override void OnButtonClick()
    {
        base.OnButtonClick();
        //_languageManager.ToggleLanguage();

        LanguageManager.ToggleLanguage();
    }
}
