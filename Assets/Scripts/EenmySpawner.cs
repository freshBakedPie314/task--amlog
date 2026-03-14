using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPositions;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private float timeBetweenSpawn = 1.5f;
    [SerializeField] private float minTimeBetweenSpawn = 1.5f;
    [SerializeField] private float speedIncDelta = 0.2f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private int nextCoinCountToUpdateSpeed = 15;
    private int deltaCoinCountToUpdateSpeed;
    private float timeTillSpawn;

    private void Start()
    {
        deltaCoinCountToUpdateSpeed = nextCoinCountToUpdateSpeed;
    }
    void Update()
    {

        if(GameManager.Instance.coins >= nextCoinCountToUpdateSpeed)
        {
            timeBetweenSpawn = Mathf.Max(timeBetweenSpawn - speedIncDelta, minTimeBetweenSpawn);
            nextCoinCountToUpdateSpeed += deltaCoinCountToUpdateSpeed;
        }

        if (timeTillSpawn <= 0f)
        {
            SpawnWave();
            timeTillSpawn = timeBetweenSpawn;
        }
        else
        {
            timeTillSpawn -= Time.deltaTime;
        }
    }

    void SpawnWave()
    {
        int safeIndex = Random.Range(0, spawnPositions.Length);
        int spawnCount = Random.Range(1, 3);

        for (int i = 0; i < spawnPositions.Length; i++)
        {
            if (i == safeIndex)
            {
                SpawnItem(coinPrefab, spawnPositions[i].position);
                continue;
            }

            if (spawnCount == 1)
            {
                if (i != (safeIndex + 1) % spawnPositions.Length) continue;
            }

            SpawnItem(enemyPrefab, spawnPositions[i].position);
        }
    }

    void SpawnItem(GameObject prefab, Vector3 position)
    {
        GameObject go = Instantiate(prefab, position, Quaternion.identity);
        go.GetComponent<Rigidbody2D>().linearVelocity = Vector2.down * moveSpeed;
    }
}