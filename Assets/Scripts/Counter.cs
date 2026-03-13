using System;

public class Counter
{
    private int _count;

    public int Count => _count;

    public event Action<int> CountChanged;

    public void Increment()
    {
        _count++;
        CountChanged?.Invoke(_count);
    }

    public void Reset()
    {
        _count = 0;
        CountChanged?.Invoke(_count);
    }
}