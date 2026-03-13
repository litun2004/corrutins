using System.Collections;
using UnityEngine;

public class CounterController : MonoBehaviour
{
    [SerializeField] private CounterView _view;
    [SerializeField] private float _delay = 0.5f;

    private CounterModel _model;
    private bool _isCounting;
    private Coroutine _coroutine;

    private void Start()
    {
        _model = new CounterModel();
        _model.CountChanged += OnCountChanged;
        OnCountChanged(_model.Count);
    }

    private void OnDestroy()
    {
        if (_model != null)
        {
            _model.CountChanged -= OnCountChanged;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isCounting)
            {
                StopCounting();
            }
            else
            {
                StartCounting();
            }
        }
    }

    private void StartCounting()
    {
        _isCounting = true;
        _coroutine = StartCoroutine(CountUp());

        Debug.Log($"Нажатие 1: {_isCounting}");
    }

    private void StopCounting()
    {
        _isCounting = false;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        Debug.Log($"Нажатие 2: {_isCounting}");
    }

    private IEnumerator CountUp()
    {
        while (_isCounting)
        {
            _model.Increment();         
            yield return new WaitForSeconds(_delay);
        }
    }

    private void OnCountChanged(int newCount)
    {
        _view.UpdateCount(newCount);
    }
}