using Main.ScriptableObjects;
using UnityEngine;

namespace Main.Scripts.Core
{
    public class HealthManager : MonoBehaviour
    {
        private Health _shooterHealth;
        private Health _supportHealth;
        private Health _damageReceiverHealth = new Health();
        private PlayersHp _currentReceiver;
    
        [SerializeField] private PlayerSO shooterPlayerData;
        [SerializeField] private PlayerSO supportPlayerData;
        
        public ref Health ShooterHealth => ref _shooterHealth;
        public ref Health SupportHealth => ref _supportHealth;
        public ref Health ReceiverHealth => ref _damageReceiverHealth; // Needed for debug
        public PlayersHp CurrentReceiver => _currentReceiver; //Will be needed to show who is receiver in UI
    
        void Awake()
        {
            _shooterHealth = new Health(shooterPlayerData.healthPoints);
            _supportHealth = new Health(supportPlayerData.healthPoints);
            _damageReceiverHealth = _shooterHealth;
        }
    
        public void HealPlayer(PlayersHp playerHp, int value)
        {
            switch (playerHp)
            {
                case PlayersHp.Shooter: _shooterHealth.Heal(value); break;
                case PlayersHp.Support: _supportHealth.Heal(value); break;
                default: _damageReceiverHealth = _shooterHealth; break;
            }
        }
        
        public void Damage(int value)
        {
            _damageReceiverHealth.Damage(value);
        }
        
        public void SwitchReceiver()
        {
            switch (_currentReceiver)
            {
                case PlayersHp.Shooter:
                    _damageReceiverHealth = SupportHealth;
                    _currentReceiver = PlayersHp.Support;
                    break;
                case PlayersHp.Support:
                    _damageReceiverHealth = ShooterHealth;
                    _currentReceiver = PlayersHp.Shooter;
                    break;
                default:
                    Debug.LogWarning("Hey, some weird stuff here");
                    break;
            }
            Debug.Log($"Current receiver is {_currentReceiver}");
        }
        
        public enum PlayersHp
        {
            Shooter,
            Support
        }
    }
}

