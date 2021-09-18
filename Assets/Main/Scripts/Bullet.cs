using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private Timer _destroyTimer;
    [SerializeField] private float destroyTime = 2f;
    void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _rb2d.velocity = transform.right * 20f;
        
        _destroyTimer = gameObject.AddComponent<Timer>();
        _destroyTimer.TimeInSeconds = destroyTime;
        _destroyTimer.StartTimer();
    }

    void Update()
    {
        if (!_destroyTimer.isTurnedOn)
            Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
