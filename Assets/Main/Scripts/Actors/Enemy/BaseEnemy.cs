using Main.Scripts.Core;
using Main.Scripts.Enemy.Data;
using UnityEngine;
using UnityEngine.Events;

namespace Main.Scripts.Actors.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class BaseEnemy : MonoBehaviour, IEnemy
    {
        protected Rigidbody2D rigidbody2D;
        protected Transform enemyTransform;
        protected Transform target;

        protected BaseEnemySO baseEnemySO;
        protected Health health;
        protected EnemyData enemyData;

        public UnityEvent OnHealth;

        public void SubscribeOnHealthEvent(UnityAction action)
        {
            OnHealth.AddListener(action);
        }

        protected virtual void Awake()
        {
            enemyTransform = transform;

            if (rigidbody2D == null) rigidbody2D = GetComponentInParent<Rigidbody2D>();
        }

        protected virtual void OnEnable()
        {
            SubscribeOnHealthEvent(CheckHealth);
        }

        public virtual void Setup(EnemyData enemyData)
        {
            this.enemyData = enemyData;
            baseEnemySO = enemyData.BaseEnemySO;
            health = new Health(baseEnemySO.HealthPoints);
            target = enemyData.Target;
        }

        protected virtual void Update()
        {
            Move();
        }

        public virtual void Move()
        {
            if (target == null) return;
            
            //Instead Vector3.Distance, because of optimization
            var distance = Mathf.Sqrt((target.position - enemyTransform.position).sqrMagnitude);

            if (distance > baseEnemySO.StopDistance)
            {
                enemyTransform.position = Vector2.MoveTowards(enemyTransform.position, target.position,
                    baseEnemySO.MovementSpeed * Time.deltaTime);
            }
        }

        public virtual void Attack()
        {
            //TODO: @Ilyas Attack
        }

        public virtual void Damage(int value)
        {
            if (gameObject != null) health.Damage(value);
            
            OnHealth?.Invoke();
        }

        public void CheckHealth()
        {
            if (health.CurrentHealth <= 0)
            {
                Destroy(gameObject);
            }
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

            Debug.LogWarning("Missing reference to HealthManager");
        }

        protected virtual void OnDisable()
        {
            OnHealth.RemoveAllListeners();
        }
    }
}