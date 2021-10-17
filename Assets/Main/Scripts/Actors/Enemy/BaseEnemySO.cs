using Sirenix.OdinInspector;
using UnityEngine;

namespace Main.Scripts.Actors.Enemy
{
    public class BaseEnemySO : ScriptableObject
    {
        [BoxGroup("Enemy Setup")] public BaseEnemy EnemyPrefab;
        [BoxGroup("Enemy Setup")] public Sprite Sprite;
    
        [BoxGroup("Enemy Settings"), Range(0f, 50f)] public float MovementSpeed = 1f;
        [BoxGroup("Enemy Settings"),MinValue(1)] public int HealthPoints = 1;
        [BoxGroup("Enemy Settings"), MinValue(1)] public int AttackDamage = 5;
        [BoxGroup("Enemy Settings"), MinValue(.1f)] public float StopDistance = 1f;
    }
}

