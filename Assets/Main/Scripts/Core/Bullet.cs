using Main.Scripts.Interface;
using UnityEngine;

namespace Main.Scripts.Core
{
    public class Bullet : MonoBehaviour
    {
        private Rigidbody2D _rb2d;
        private Timer _destroyTimer;
        [SerializeField] private float destroyTime = 2f;
        [SerializeField] private ParticleSystem particles;

        private void Awake()
        {
            _rb2d = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _rb2d.velocity = transform.right * 20f;

            _destroyTimer = gameObject.AddComponent<Timer>();
            _destroyTimer.TimeInSeconds = destroyTime;
            _destroyTimer.StartTimer();
        }

        private void Update()
        {
            if (!_destroyTimer.isTurnedOn)
                Destroy(gameObject);
        }

        private void DestroyParticle()
        {
            particles.transform.parent = null;
            particles.Play();
            Destroy(particles.gameObject, destroyTime);
            Destroy(gameObject);
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out IDamageable enemy))
            {
                enemy.Damage(10);
            }

            DestroyParticle();
        }
    }   
}