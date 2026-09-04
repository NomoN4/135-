using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameSceneInitializer : MonoBehaviour
{
    [SerializeField] private TMP_Text floorText;
    void Start()
    {
        Debug.Log("ゲームシーンに入った！");
        EnemySpawner.Instance.SpawnEnemies(GameManager.Instance.floor);
        floorText.text = GameManager.Instance.floor.ToString() + "F";
    }
}