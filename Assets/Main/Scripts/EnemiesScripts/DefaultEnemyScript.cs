using UnityEngine;

public class DefaultEnemyScript : MonoBehaviour
{
    private HealthManager _healthManager;
    
    void Awake()
    {
        _healthManager = FindObjectOfType<HealthManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;
        _healthManager.Damage(10);
        Debug.Log(_healthManager.ReceiverHealth.Current);
    }
}
