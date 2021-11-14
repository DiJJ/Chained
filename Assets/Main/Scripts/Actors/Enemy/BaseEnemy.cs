using Main.Scripts.Core;
using Main.Scripts.Enemy;
using Main.Scripts.Interface;
using UnityEngine;

namespace Main.Scripts.Actors.Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class BaseEnemy : MonoBehaviour, IEnemy<EnemyData, HealthManager>
    {
        [SerializeField] private bool _enableAI = true;
        
        protected Rigidbody2D rigidbody2D;
        protected Transform enemyTransform;
        protected Transform target;

        protected Health enemyHealth;
        protected EnemyData enemyData;

        protected virtual void Awake()
        {
            enemyTransform = transform;

            if (rigidbody2D == null) rigidbody2D = GetComponentInParent<Rigidbody2D>();
        }

        protected virtual void Start()
        {
            enemyHealth?.SubscribeOnDamageAction(CheckHealth);
        }
        
        public virtual void Setup(EnemyData enemyData)
        {
            if (enemyData == null) return;
            
            this.enemyData = enemyData;
            enemyHealth = new Health(enemyData.BaseEnemySO.HealthPoints);
            target = enemyData.Target;
        }

        protected virtual void Update()
        {
            if (!_enableAI) return;
            
            Move();
        }

        public virtual void Move()
        {
            if (target == null) return;

            var distance = GetDistanceToTarget();

            if (distance > enemyData.BaseEnemySO.StopDistance)
            {
                enemyTransform.position = Vector2.MoveTowards(enemyTransform.position, target.position,
                    enemyData.BaseEnemySO.MovementSpeed * Time.deltaTime);
            }
        }

        //Instead Vector3.Distance, because of optimization
        private float GetDistanceToTarget() => Mathf.Sqrt((target.position - enemyTransform.position).sqrMagnitude);
        

        public virtual void Attack(HealthManager healthManager)
        {
            healthManager.Damage(enemyData.BaseEnemySO.AttackDamage);
        }

        public virtual void Damage(int value)
        {
            if (gameObject != null) enemyHealth.Damage(value);
        }

        public void CheckHealth()
        {
            if (enemyHealth.CurrentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

        protected virtual void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag(TagConstants.Player)) return;

            var obj = GameObject.FindWithTag(TagConstants.HealthManager);
            if (obj.TryGetComponent(out HealthManager playerHealthManager))
            {
                Attack(playerHealthManager);
                return;
            }

            Debug.LogWarning("Missing reference to HealthManager");
        }
    }
}