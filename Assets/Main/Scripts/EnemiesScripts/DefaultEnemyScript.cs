using UnityEngine;

public class DefaultEnemyScript : MonoBehaviour
{
    [SerializeField] private DefaultEnemySObj enemyData;
    [SerializeField] private Rigidbody2D rb2d;

    public Health health;

    void Start()
    {
        health = new Health(enemyData.healthPoints);
    }

    void Update()
    {
        if (health.Current <= 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;
        var obj = GameObject.FindWithTag("HealthManager");
        if (obj.TryGetComponent(out HealthManager healthManager))
        {
            healthManager.Damage(enemyData.attackDamage);
            Debug.Log(healthManager.ReceiverHealth.Current);
        }
        else
            Debug.LogWarning("Yo maan, there is no health manager in a scene!!");
    }
}
