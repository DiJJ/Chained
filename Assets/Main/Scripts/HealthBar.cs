using Main.Scripts.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Main.Main.Scripts
{
    public class HealthBar : MonoBehaviour
    {
        private HealthManager _healthManager;

        [SerializeField] private Slider _slider;
        
        private void Awake()
        {
            _healthManager = FindObjectOfType<HealthManager>();
        }

        private void Start()
        {
            SetupSlider();
            _healthManager.ReceiverHealth.SubscribeOnDamageAction(UpdateHealth);
            _healthManager.ReceiverHealth.SubscribeOnHealAction(UpdateHealth);
        }

        private void SetupSlider()
        {
            _slider.maxValue = _healthManager.ReceiverHealth.Max;
            _slider.value = _healthManager.ReceiverHealth.CurrentHealth;
        }

        private void UpdateHealth()
        {
            _slider.value = _healthManager.ReceiverHealth.CurrentHealth;
        }
    }
}