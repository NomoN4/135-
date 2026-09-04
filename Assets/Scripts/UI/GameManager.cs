using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int floor = 1;
    public bool bossBattle = false;
    public Transform playerSpawnPoint;
    public Transform player;
    [SerializeField] private TMP_Text floorText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //EnemySpawner.Instance.SpawnEnemies(floor);
        //floorText.text = floor.ToString() + "F";
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
        floorText.text = floor.ToString() + "F";

    }

    public void StartBossBattle()
    {
        bossBattle = true;

        EnemySpawner.Instance.SpawnBoss();
    }
}