using Main.Scripts.Core;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UnityTemplateProjects.Actors.Player
{
    public class HealthBar : MonoBehaviour
    {
        private HealthManager _healthManager;
        private UnityAction UpdateAction;

        [SerializeField] private Slider _slider;
        
        private void Start()
        {
            _healthManager = FindObjectOfType<HealthManager>();
            SetupSlider();
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

        private void OnEnable()
        {
            _healthManager.ReceiverHealth.SubscribeOnDamage(UpdateHealth);
            _healthManager.ReceiverHealth.SubscribeOnHeal(UpdateHealth);
        }
    }
}