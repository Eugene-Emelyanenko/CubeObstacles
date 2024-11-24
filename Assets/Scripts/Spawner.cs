using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject enemyPrefab;

    public float coinSpawnInterval = 2f;
    public float enemySpawnInterval = 3f;

    public float maxX;
    public float minX;

    [SerializeField] private Score score;

    private void Start()
    {
        StartCoroutine(SpawnCoin());
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnCoin()
    {
        while (true)
        {
            GameObject coin = Instantiate(coinPrefab, new Vector2(Random.Range(minX, maxX), transform.position.y), Quaternion.identity);

            coin.GetComponent<Coin>().speed += score.score / 10f;

            coinSpawnInterval -= score.score / 10f;

            if (coinSpawnInterval < 1.5f)
                coinSpawnInterval = 1.5f;

            yield return new WaitForSeconds(coinSpawnInterval);
        }
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject enemy = Instantiate(enemyPrefab, new Vector2(Random.Range(minX, maxX), transform.position.y), Quaternion.identity);

            enemy.GetComponent<Enemy>().speed += score.score / 10f;

            enemySpawnInterval -= score.score / 10f;

            if (enemySpawnInterval < 0.5f)
                enemySpawnInterval = 0.5f;
            
            yield return new WaitForSeconds(enemySpawnInterval);
        }
    }
}
