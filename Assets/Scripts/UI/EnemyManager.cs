using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    private int enemyCount = 0;

    void Awake()
    {
        Instance = this;
    }

    public void AddEnemy()
    {
        enemyCount++;
    }

    public void EnemyDead()
    {
        enemyCount--;

        Debug.Log("残りの敵：" + enemyCount);

        if (enemyCount <= 0)
        {
            GameManager.Instance.EnemyClear();
        }
    }
}