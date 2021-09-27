using UnityEngine;

public class RandomEnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoint;
    [SerializeField] private GameObject[] enemies;

    private int rand;
    private int randPosition;
    public float startTimeSpawns;
    private float timeSpawns;

    void Start()
    {
        timeSpawns = startTimeSpawns;   
    }

    void Update()
    {
        if (timeSpawns <= 0)
        {
            rand = Random.Range(0, enemies.Length - 1);
            randPosition = Random.Range(0, spawnPoint.Length);
            Instantiate(enemies[rand], spawnPoint[randPosition].transform.position, Quaternion.identity);
            timeSpawns = startTimeSpawns;
        }
        else
        {
            timeSpawns -= Time.deltaTime;
        }   
    }
}
