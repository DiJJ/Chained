using Main.Scripts.Core;
using Main.Scripts.Enemy;

namespace Main.Scripts.Interface
{
    public interface IEnemy : IDamageable
    {
        void Setup(EnemyData enemyData);
        void Move();
        void Attack(HealthManager healthManager);
    }
}

