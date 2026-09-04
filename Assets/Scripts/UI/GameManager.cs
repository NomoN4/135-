using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int floor = 1;
    public bool bossBattle = false;
    public Transform playerSpawnPoint;
    public Transform player;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        EnemySpawner.Instance.SpawnEnemies(floor);
    }

    public void EnemyClear()
    {
        Debug.Log("敵全滅");

        BuffManager.Instance.OpenBuffUI();
    }

    public void NextBattle()
    {
        floor++;

        EnemySpawner.Instance.SpawnEnemies(floor);
        player.position = playerSpawnPoint.position;

    }

    public void StartBossBattle()
    {
        bossBattle = true;

        EnemySpawner.Instance.SpawnBoss();
    }
}