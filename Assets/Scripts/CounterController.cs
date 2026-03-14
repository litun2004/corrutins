using System.Collections;
using UnityEngine;

public class CounterController : MonoBehaviour
{
    [SerializeField] private View _view;
    [SerializeField] private float _delay = 0.5f;

    [SerializeField] private InputReader _inputReader;
    private Counter _model;
    private Coroutine _countCoroutine;

    private void Start()
    {
        _model = new Counter();
        _inputReader.Clicked += OnClicked;

        UpdateView(_model.Count);
    }

    private void OnDestroy()
    {
        _inputReader.Clicked -= OnClicked;

        if (_countCoroutine != null)
        {
            StopCoroutine(_countCoroutine);
        }
    }

    private void OnClicked()
    {
        if (_countCoroutine != null)
        {
            StopCounting();

            Debug.Log($"Нажатие 2:");
        }
        else
        {
            StartCounting();

            Debug.Log($"Нажатие 1:");
        }
    }

    private void StartCounting()
    {
        _countCoroutine = StartCoroutine(CountUp());

    }

    private void StopCounting()
    {
        if (_countCoroutine != null)
        {
            StopCoroutine(_countCoroutine);
            _countCoroutine = null;
        }       
    }

    private IEnumerator CountUp()
    {
        while (true)
        {
            _model.Increment();
            UpdateView(_model.Count);
            yield return new WaitForSeconds(_delay);
        }
    }

    private void UpdateView(int count)
    {
        _view.UpdateCount(count);
    }
}