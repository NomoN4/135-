using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TMP_Text floorText;
    public void BackToTitle()
    {
        // リセット
        GameManager.Instance.floor = 1;

        // タイトルへ
        SceneManager.LoadScene("Tutorial");
        EnemySpawner.Instance.SpawnEnemies(GameManager.Instance.floor);
    }

    void Start()
    {
        floorText.text = "Retult: " + GameManager.Instance.floor + "F";
    }
}