using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PressableButton : MonoBehaviour
{
    protected Button _button;
    protected virtual void Awake()
    {
        _button = GetComponent<Button>();
        
        _button.onClick.AddListener(ButtonClick);
    }

    protected virtual void ButtonClick()
    {
        
    }

}
