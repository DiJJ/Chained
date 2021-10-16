using Main.Scripts.Enemy.Data;

public interface IEnemy : IDamageable
{
   void Setup(EnemyData enemyData);
   void Move();
   void Attack();
}
