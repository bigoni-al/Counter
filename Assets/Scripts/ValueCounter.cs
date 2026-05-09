using TMPro;
using UnityEngine;

public class ValueCounter : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private TextMeshProUGUI _textValue;

    private void Awake()
    {
        _textValue = GetComponent<TextMeshProUGUI>();
        _textValue.text = _counter.ValueCounter.ToString();
    }

    private void OnEnable()
    {
        _counter.ValueChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= ChangeValue;
    }

    private void ChangeValue()
    {
        _textValue.text = _counter.ValueCounter.ToString();
    }
}