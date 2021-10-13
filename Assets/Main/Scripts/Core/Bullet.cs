using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private Timer _destroyTimer;
    [SerializeField] private float destroyTime = 2f;
    [SerializeField] private ParticleSystem particles;
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
        if (other.gameObject.CompareTag("Damageable"))
        {
            var damageable = other.gameObject;
            if (damageable.TryGetComponent(out DefaultEnemyScript enemy))
            {
                enemy.health.Damage(10);
                Debug.Log(enemy.health.CurrentHealth);
            }
        }
        particles.transform.parent = null;
        particles.Play();
        Destroy(gameObject);
    }
}
