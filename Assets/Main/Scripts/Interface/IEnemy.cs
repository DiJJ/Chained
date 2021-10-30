namespace Main.Scripts.Interface
{
    public interface IEnemy<T, U> : IDamageable
    {
        void Setup(T enemyData);
        void Move();
        void Attack(U healthManager);
    }
}

