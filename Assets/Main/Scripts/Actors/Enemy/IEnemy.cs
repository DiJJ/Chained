using Main.Scripts.Core;
using Main.Scripts.Interface;

namespace Main.Scripts.Actors.Enemy
{
    public interface IEnemy : IDamageable
    {
        void Setup(EnemyData enemyData);
        void Move();
        void Attack(HealthManager healthManager);
    }
}

