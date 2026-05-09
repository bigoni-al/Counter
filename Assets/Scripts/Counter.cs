using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private CounterButton _counterButton;
    [SerializeField] private float _delay;

    private TextMeshProUGUI _textCounter;
    private WaitForSecondsRealtime _wait;
    private Coroutine _coroutine;

    private string _textStatus1 = "—чЄтчик неактивен";
    private string _textStatus2 = "—чЄтчик активен    ";

    private float _valueCounter = 0.0f;
    private float _stepCounter = 1.0f;

    private bool _isCounterActive = false;

    private void Awake()
    {
        _textCounter = GetComponent<TextMeshProUGUI>();
        _wait = new WaitForSecondsRealtime(_delay);
    }

    private void OnEnable()
    {
        _counterButton.ButtonPushed += ChangeJobsCounter;
    }

    private void Update()
    {
        if (_isCounterActive == false)
        {
            _textCounter.text = _textStatus1 + " " + _valueCounter;
        }
        else
        {
            _textCounter.text = _textStatus2 + " " + _valueCounter;
        }
    }

    private void OnDisable()
    {
        _counterButton.ButtonPushed -= ChangeJobsCounter;
    }

    private void ChangeJobsCounter()
    {
        if (_isCounterActive == false)
        {
            _coroutine = StartCoroutine(EnumerateCounterValue());
            _isCounterActive = true;
            Debug.Log("—чЄтчик заупущен");
        }
        else
        {
            StopCoroutine(_coroutine);
            _isCounterActive = false;
            Debug.Log("—чЄтчик остановлен");
        }
    }

    private IEnumerator EnumerateCounterValue()
    {
        while (true)
        {
            yield return _wait;

            _valueCounter += _stepCounter;
        }
    }
}