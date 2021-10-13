using UnityEngine;
using UnityEngine.Serialization;

public class BaseEnemySO : ScriptableObject
{
    public Sprite Sprite;
    [Range(0,50)] public int MovementSpeed;
    public int HealthPoints;
    public int AttackDamage;
}
