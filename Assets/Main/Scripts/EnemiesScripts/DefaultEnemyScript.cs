using UnityEngine;

public class DefaultEnemyScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;
        var obj = GameObject.FindWithTag("HealthManager");
        if (obj.TryGetComponent(out HealthManager healthManager))
        {
            healthManager.Damage(10);
            Debug.Log(healthManager.ReceiverHealth.Current);
        }
        else
            Debug.LogWarning("Yo maan, there is no health manager in a scene!!");
    }
}
