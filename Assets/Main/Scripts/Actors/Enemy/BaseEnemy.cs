using Main.Scripts.Enemy.Data;
using UnityEngine;

namespace Main.Scripts.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class BaseEnemy : MonoBehaviour, IEnemy
    {
        protected BaseEnemySO BaseEnemySO;
        protected Rigidbody2D Rigidbody2D;
        protected Health Health;

        protected virtual void Awake()
        {
            if (Rigidbody2D == null) Rigidbody2D = GetComponentInParent<Rigidbody2D>();
        }

        protected virtual void Update()
        {
            if (Health.CurrentHealth <= 0) Destroy(gameObject);
        }

        public virtual void Setup(EnemyData enemyData)
        {
            BaseEnemySO = enemyData.BaseEnemySO;
            Health = new Health(BaseEnemySO.HealthPoints);
        }
        
        public virtual void Move()
        {
            //TODO: @Ilyas Move
        }

        public virtual void Attack()
        {
            //TODO: @Ilyas Attack
        }

        protected virtual void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            
            var obj = GameObject.FindWithTag("HealthManager");
            if (obj.TryGetComponent(out HealthManager healthManager))
            {
                healthManager.Damage(BaseEnemySO.AttackDamage);
                Debug.Log(healthManager.ReceiverHealth.CurrentHealth);
                return;
            }
            
            Debug.LogWarning("Yo maan, there is no health manager in a scene!!");
        }
    }
}