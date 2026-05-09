using System.Collections;
using UnityEngine;
using System;

public class Counter : MonoBehaviour
{
    [SerializeField] private CounterButton _counterButton;
    [SerializeField] private float _delay;

    private WaitForSecondsRealtime _wait;
    private Coroutine _coroutine;

    private float _valueCounter = 0.0f;
    private float _stepCounter = 1.0f;

    private bool _isCounterActive = false;

    public event Action ValueChanged;

    public float ValueCounter => _valueCounter;
    public bool IsCounterActive => _isCounterActive;

    private void Awake()
    {
        _wait = new WaitForSecondsRealtime(_delay);
    }

    private void OnEnable()
    {
        _counterButton.ButtonPushed += ChangeJobsCounter;
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
            Debug.Log("The counter has started");
        }
        else
        {
            StopCoroutine(_coroutine);
            _isCounterActive = false;
            Debug.Log("The counter has stopped");
        }
    }

    private IEnumerator EnumerateCounterValue()
    {
        while (true)
        {
            yield return _wait;

            _valueCounter += _stepCounter;
            ValueChanged?.Invoke();
        }
    }
}
