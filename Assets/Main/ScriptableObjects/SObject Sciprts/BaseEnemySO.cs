using Main.Scripts.Actors.Enemy;
using Sirenix.OdinInspector;
using UnityEngine;

public class BaseEnemySO : ScriptableObject
{
    [BoxGroup("Enemy Setup")] public BaseEnemy EnemyPrefab;
    [BoxGroup("Enemy Setup")] public Sprite Sprite;
    
    [BoxGroup("Enemy Settings"), Range(0f,50f)] public float MovementSpeed;
    [BoxGroup("Enemy Settings"),MinValue(1)] public int HealthPoints;
    [BoxGroup("Enemy Settings"), MinValue(1)] public int AttackDamage;
    [BoxGroup("Enemy Settings"), MinValue(.1f)] public float StopDistance = 1f;
}
