using System;
using UnityEngine;
using UIButton = UnityEngine.UI.Button;

[RequireComponent(typeof(UIButton))]
public class Button : MonoBehaviour
{
    private UIButton _button;

    public event Action Clicked;

    private void Awake()
    {
        _button = GetComponent<UIButton>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        Clicked?.Invoke();
    }
}
