using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonComponent : MonoBehaviour
{
    public abstract Button _button { get; set; }


    public virtual void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(delegate { OnButtonClick(); });
    }

    public virtual void OnButtonClick()
    {
        //play purchase sound
        //Close purchase panel (if opened one)
    }
}
