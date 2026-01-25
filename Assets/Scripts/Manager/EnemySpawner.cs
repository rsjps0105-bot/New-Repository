using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public Transform[] spawnPoints;      // 出現ポイント
    public GameObject enemyPrefab;       // 生成する敵
    public float spawnInterval = 7f;     // ～秒ごとに出す
    public float fixedY = 1f;            // Y座標固定
    public float fixedZ = 7f;            // Z座標固定
    public float fixedX = 0f;
    private float timer;

    [Header("Step Scaling")]
    public float stepTime = 30f;       // 何秒ごとに
    public float stepDecrease = 1f;  // どれだけ短くするか
    public float minSpawnInterval = 1.5f;

    [Header("Enemy Scaling")]
    public int hpIncreasePerStep = 1;
    public int maxHpBonus = 10;

    int currentHpBonus = 0;

    float elapsedTime;
    float nextStepTime;

    [Header("Limit")]
    public int maxEnemyCount = 3;

    void Start()
    {
        nextStepTime = stepTime;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= nextStepTime)
        {
            spawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - stepDecrease);

            currentHpBonus = Mathf.Min(
               maxHpBonus,
               currentHpBonus + hpIncreasePerStep
           );

            nextStepTime += stepTime;
        }

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            TrySpawnEnemy();
            timer = 0f;
        }
    }

    void TrySpawnEnemy()
    {
        // ★ 上限チェック
        int currentEnemyCount = FindObjectsOfType<Enemy>().Length;
        if (currentEnemyCount >= maxEnemyCount)
            return;

        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        if (spawnPoints.Length == 0 || enemyPrefab == null) return;

        // ランダムなスポーン地点を選ぶ
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // X は SpawnPoint、Y/Z は固定
        Vector3 spawnPosition = new Vector3(fixedX, fixedY, fixedZ);

        GameObject enemy = Instantiate(
            enemyPrefab,
            spawnPosition,
            spawnPoint.rotation
        );

        Health health = enemy.GetComponent<Health>();
        if (health != null)
        {
            health.AddMaxHp(currentHpBonus);
        }
    }
}
