using UnityEngine;
using UnityEngine.Serialization;

//TODO: @Didar delete this script after test

public class DefaultEnemyScript : MonoBehaviour
{
    [FormerlySerializedAs("enemyData")] [SerializeField] private DefaultBaseEnemySO _baseEnemyData;
    [SerializeField] private Rigidbody2D rb2d;

    public Health health;

    void Start()
    {
        health = new Health(_baseEnemyData.HealthPoints);
    }

    void Update()
    {
        if (health.CurrentHealth <= 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;
        var obj = GameObject.FindWithTag("HealthManager");
        if (obj.TryGetComponent(out HealthManager healthManager))
        {
            healthManager.Damage(_baseEnemyData.AttackDamage);
            Debug.Log(healthManager.ReceiverHealth.CurrentHealth);
        }
        else
        {
            Debug.LogWarning("Yo maan, there is no health manager in a scene!!");
        }
    }
}
