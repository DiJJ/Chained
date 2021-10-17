using UnityEngine;

namespace Main.ScriptableObjects
{
    public abstract class PlayerSO : ScriptableObject
    {
        public Sprite sprite;
        [Range(0,50)] public int movementSpeed;
        public int healthPoints;
    }
}

