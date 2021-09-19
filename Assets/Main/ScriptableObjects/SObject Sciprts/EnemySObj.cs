using UnityEngine;

public class EnemySObj : ScriptableObject
{
    public Sprite sprite;
    [Range(0,50)] public int movementSpeed;
    public int healthPoints;
    public int attackDamage;
}
