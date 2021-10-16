using UnityEngine;
using UnityEngine.Events;

namespace Main.Scripts.Core
{
    public class Health
    {
        private int _healthPoints;
        private int _maxHealthPoints;

        public UnityEvent OnHealEvent = new UnityEvent();
        public UnityEvent OnDamageEvent = new UnityEvent();

        public int Min { set; get; }
        public int Max
        {
            get => _maxHealthPoints;
    
            set
            {
                if (value > Min)
                    _maxHealthPoints = value;
                else
                {
                    _maxHealthPoints = Min + 1;
                }
            }
        }
    
        public int CurrentHealth
        {
            set
            {
                value = Mathf.Clamp(value, Min, Max);
                _healthPoints = value;
            }
            get => _healthPoints;
        }
    
        public Health()
        {
            Min = 0;
            Max = 100;
            CurrentHealth = Max;
            
        }
    
        public Health(int maximal)
        {
            Min = 0;
            Max = maximal;
            CurrentHealth = Max;
        }
    
        public Health(int maximal, int currentHealth)
        {
            Min = 0;
            Max = maximal;
            CurrentHealth = currentHealth;
        }
    
        public Health(int maximal, int currentHealth, int minimal)
        {
            Min = minimal;
            Max = maximal;
            CurrentHealth = currentHealth;
        }
    
        public void Damage(int value)
        {
            CurrentHealth -= value;
            
            OnDamageEvent?.Invoke();
        }
    
        public void Heal(int value)
        {
            CurrentHealth += value;
            
            OnHealEvent?.Invoke();
        }

        public void SubscribeOnHeal(UnityAction action)
        {
            OnHealEvent.AddListener(action);
        }

        public void SubscribeOnDamage(UnityAction action)
        {
            OnDamageEvent.AddListener(action);
        }
    }
}

