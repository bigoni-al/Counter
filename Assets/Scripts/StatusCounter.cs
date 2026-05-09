using TMPro;
using UnityEngine;

public class StatusCounter : MonoBehaviour
{
    [SerializeField] private CounterButton _counterButton;
    [SerializeField] private Counter _counter;

    private TextMeshProUGUI _textStatus;

    private string _textStatus1 = "Counter is inactive";
    private string _textStatus2 = "Counter is active";

    private void Awake()
    {
        _textStatus = GetComponent<TextMeshProUGUI>();
        _textStatus.text = _textStatus1;
    }

    private void OnEnable()
    {
        _counterButton.ButtonPushed += DisplayCounterStatus;
    }

    private void OnDisable()
    {
        _counterButton.ButtonPushed -= DisplayCounterStatus;
    }

    private void DisplayCounterStatus()
    {
        if (_counter.IsCounterActive == false)
        {
            _textStatus.text = _textStatus2;
            Debug.Log("The counter status was changed to active");
        }
        else
        {
            _textStatus.text = _textStatus1;
            Debug.Log("The counter status was changed to inactive");
        }
    }
}