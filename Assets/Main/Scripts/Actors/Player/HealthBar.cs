using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityTemplateProjects.Actors.Player
{
    public class HealthBar : MonoBehaviour
    {
        private HealthManager _healthManager;

        [SerializeField] private Slider _slider;
        
        private void Start()
        {
            _healthManager = FindObjectOfType<HealthManager>();
            _slider.maxValue = _healthManager.ReceiverHealth.Max;
        }
        
        private void Update()
        {
            _slider.value = _healthManager.ReceiverHealth.CurrentHealth;
        }
    }
}