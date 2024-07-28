using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class LanguageSprite : MonoBehaviour
{

    [SerializeField] private LanguageDependentSprite _languageDependentSprite;

    private Image _image;

    void Start()
    {
        _image = GetComponent<Image>();
        LanguageManager.OnLanguageChange += (language) => ChangeLanguageSprite();

        ChangeLanguageSprite();
    }

    private void ChangeLanguageSprite()
    {
        _image.sprite = _languageDependentSprite.GetSprite(LanguageManager.SelectedLanguage);
    }
}
