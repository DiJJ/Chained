using UnityEngine;

public class Timer : MonoBehaviour
{

    private float _time;
    private float _currentTime;
    
    [HideInInspector] public bool isTurnedOn;
    [HideInInspector] public bool isLooped;
    public float TimeInSeconds
    {
        set => _time = value <= 0 ? .01f : value;
    }

    public void StartTimer()
    {
        _currentTime = _time;
        isTurnedOn = true;
    }

    public void StopTimer()
    {
        isTurnedOn = false;
    }

    private void Update()
    {
        if (!isTurnedOn)
            return;
        
        _currentTime -= Time.deltaTime;
        
        if (_currentTime <= 0)
        {
            if (isLooped)
            {
                _currentTime = _time;
                return;
            }
            
            StopTimer();
        }
    }
}
