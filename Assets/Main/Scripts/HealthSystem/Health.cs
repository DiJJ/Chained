using UnityEngine;

public class Health
{
    private int _healthPoints;
    private int _maxHealthPoints;

    public int Min { set; get; }
    public int Max
    {
        set
        {
            if (value > Min)
                _maxHealthPoints = value;
            else
            {
                _maxHealthPoints = Min + 1;
            }
        }

        get => _maxHealthPoints;
    }
    public int Current
    {
        set
        {
            value = Mathf.Clamp(value, Min, Max);
            _healthPoints = value;
        }
        get => _healthPoints;
    }

    public Health()
    {
        Min = 0;
        Max = 100;
        Current = Max;
    }

    public Health(int maximal)
    {
        Min = 0;
        Max = maximal;
        Current = Max;
    }

    public Health(int maximal, int current)
    {
        Min = 0;
        Max = maximal;
        Current = current;
    }

    public Health(int maximal, int current, int minimal)
    {
        Min = minimal;
        Max = maximal;
        Current = current;
    }

    public void Damage(int value)
    {
        Current -= value;
    }

    public void Heal(int value)
    {
        Current += value;
    }
}
