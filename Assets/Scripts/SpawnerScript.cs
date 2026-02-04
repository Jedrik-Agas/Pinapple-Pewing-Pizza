using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float Radius = 1f;
    public const float BaseSpawnRate = 3f;
    public float SpawnRate = BaseSpawnRate;

    void Update()
    {
        if (SpawnRate > BaseSpawnRate)
        {
            SpawnEnemy();
            SpawnRate = 0f;
        }
        else
        {
            SpawnRate = SpawnRate + Time.deltaTime;
        }
    }

    public void SpawnEnemy()
    {
        Vector2 SpawnPosition = (Vector2)transform.position + Random.insideUnitCircle * Radius;
        Instantiate(EnemyPrefab, SpawnPosition, Quaternion.identity);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
