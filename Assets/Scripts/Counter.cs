using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _delay = 0.5f;

    private bool _isCounting = false;
    private Coroutine _coroutine;
    private int _count = 0;

    private void Start()
    {
        _text.text = "0";
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
            _count++;
            _text.text = _count.ToString();
            yield return new WaitForSeconds(_delay);          
        }
    }
}