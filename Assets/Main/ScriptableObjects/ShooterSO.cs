using UnityEngine;

namespace Main.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ShooterStatsSO", menuName = "Game/SO/Player/Shooter")]
    public class ShooterSO : PlayerSO
    {
        public float shootPaceTime;
        public GameObject bullet;
    }
}

