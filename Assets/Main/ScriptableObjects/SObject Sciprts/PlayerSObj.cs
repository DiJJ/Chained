using UnityEngine;

public abstract class PlayerSObj : ScriptableObject
{
    public Sprite sprite;
    [Range(0,50)] public int movementSpeed;
    public int healthPoints;
}
