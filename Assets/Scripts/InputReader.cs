using System.Collections;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private View _view;
    [SerializeField] private float _delay = 0.5f;

    private Model _model;
    private bool _isCounting;
    private Coroutine _coroutine;

    private void Start()
    {
        _model = new Model();
        _view.UpdateCount(_model.Count);
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
            _view.UpdateCount(_model.Count);
            yield return new WaitForSeconds(_delay);          
        }
    }
}