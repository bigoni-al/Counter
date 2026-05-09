using System;
using UnityEngine;
using UnityEngine.UI;

public class CounterButton : MonoBehaviour
{
    private Button _counterButton;

    public event Action ButtonPushed;

    private void Awake()
    {
        _counterButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _counterButton.onClick.AddListener(OnButtonPushed);
    }

    private void OnDisable()
    {
        _counterButton.onClick.RemoveListener(OnButtonPushed);
    }

    private void OnButtonPushed()
    {
        ButtonPushed?.Invoke();
        Debug.Log("Counter pushed");
    }
}