using Main.Scripts.Core;
using Main.Scripts.Enemy.Data;
using UnityEngine;

namespace Main.Scripts.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class BaseEnemy : MonoBehaviour, IEnemy
    {
        protected BaseEnemySO baseEnemySO;
        protected Rigidbody2D rigidbody2D;
        protected Health health;
        protected EnemyData enemyData;

        protected virtual void Awake()
        {
            if (rigidbody2D == null) rigidbody2D = GetComponentInParent<Rigidbody2D>();
        }

        protected virtual void Update()
        {
            if (health.CurrentHealth <= 0) Destroy(gameObject);
        }

        public virtual void Setup(EnemyData enemyData)
        {
            baseEnemySO = enemyData.BaseEnemySO;
            health = new Health(baseEnemySO.HealthPoints);
            this.enemyData = enemyData;
        }
        
        public virtual void Move()
        {
            //TODO: @Ilyas Move
        }

        public virtual void Attack()
        {
            //TODO: @Ilyas Attack
        }

        public virtual void Damage(int value)
        {
            health.Damage(value);
        }

        protected virtual void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag(TagConstants.Player)) return;
            
            var obj = GameObject.FindWithTag(TagConstants.HealthManager);
            if (obj.TryGetComponent(out HealthManager healthManager))
            {
                healthManager.Damage(baseEnemySO.AttackDamage);
                return;
            }
            
            Debug.LogWarning("Yo maan, there is no health manager in a scene!!");
        }
    }
}