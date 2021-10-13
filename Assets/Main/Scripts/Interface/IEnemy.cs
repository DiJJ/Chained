using Main.Scripts.Enemy.Data;

public interface IEnemy
{
   void Setup(EnemyData enemyData);
   void Move();
   void Attack();
}
