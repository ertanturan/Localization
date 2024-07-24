using RTLTMPro;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class TextComponent : MonoBehaviour
{
    private Text _text;

    private Text Text
    {
        get
        {
            if (!_text)
                _text = GetComponent<Text>();
            return _text;
        }
    }

    private RTLTextMeshPro _rtlText;

    protected RTLTextMeshPro RtlText
    {
        get
        {
            if (!_rtlText)
                _rtlText = GetComponent<RTLTextMeshPro>();
            return _rtlText;
        }
        set
        {
            _rtlText = value;
        }
    }

    private bool _initialized;
    
    protected virtual void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        if (_initialized) return;
        _initialized = true;
    }

    protected void SetText(string text, params object[] args)
    {
        if (Text == null)
        {
            RtlText.text = string.Format(text, args);
        }
        else
        {
            Text.text = string.Format(text, args);
        }
    }
}
