using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;

    public float spawnTime = 10f;
    public float spawnDistance = 10f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnTime);
    }

    void SpawnEnemy()
    {
        Vector2 random = Random.insideUnitCircle.normalized;

        Vector3 spawnPos = player.position + new Vector3(random.x, 0, random.y) * spawnDistance;

        GameObject enemyObj = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        Enemy enemy = enemyObj.GetComponent<Enemy>();

        enemy.player = player;
    }
}