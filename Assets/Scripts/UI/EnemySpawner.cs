using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    [System.Serializable]
    public class EnemySpawnData
    {
        public GameObject enemyPrefab;
        public Transform[] spawnPoints;
    }

    void Awake()
    {
        Instance = this;
    }

    [SerializeField] private EnemySpawnData[] enemies;
    [SerializeField] private Transform player;

    public void SpawnEnemies(int floor)
    {
        int enemyCount = 3 + floor;

        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
            EnemyManager.Instance.AddEnemy();
        }
    }

    void SpawnEnemy()
    {
        // 敵の種類をランダムに選択
        int enemyIndex = Random.Range(0, enemies.Length);
        EnemySpawnData enemy = enemies[enemyIndex];

        int pointIndex = Random.Range(0, enemy.spawnPoints.Length);

        GameObject spawnedEnemy = Instantiate(
            enemy.enemyPrefab,
            enemy.spawnPoints[pointIndex].position,
            Quaternion.identity
        );

        BirdEnemy birdEnemy = spawnedEnemy.GetComponent<BirdEnemy>();
        if(birdEnemy != null)
        {
            birdEnemy.player = player;
        }
        GunEnemy gunEnemy = spawnedEnemy.GetComponent<GunEnemy>();
        if(gunEnemy != null)
        {
            gunEnemy.player = player;
        }
    }

    public void SpawnBoss()
    {
        Debug.Log("ボス出現");

        // 後でボス生成処理を書く
    }
}