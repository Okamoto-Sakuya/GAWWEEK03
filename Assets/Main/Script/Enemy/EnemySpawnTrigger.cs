using UnityEngine;

public class EnemySpawnTrigger : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int spawnCount = 3;
    public float spawnRange = 5f;

    private bool hasSpawned = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnEnemies();
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 offset = new Vector3(
                Random.Range(-spawnRange, spawnRange),
                0,
                Random.Range(-spawnRange, spawnRange)
            );

            Vector3 spawnPos = transform.position + offset;

            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}