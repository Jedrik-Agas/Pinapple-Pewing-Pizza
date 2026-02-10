using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float Radius = 1f;
    public int EnemiesLeft = 0;
    public int SpawnCount = 0;
    public int MaxSpawnCount = 0;

    void Start()
    {

    }
    void Update()
    {
        if (EnemiesLeft <= 0)
        {
            while (SpawnCount >= 0)
            {
                SpawnEnemy();
                SetEnemiesLeft(1);
                SpawnCount = SpawnCount - 1;
            }
            MaxSpawnCount++;
            SpawnCount = MaxSpawnCount;

        }
    }

    public void SetEnemiesLeft(int EnemyCount)
    {
        EnemiesLeft = EnemiesLeft + EnemyCount;
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
