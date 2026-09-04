using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;
    private MainCharaHealth health;


    [Header("基本ステータス")]
    public  int attackPower = 0;
    public float moveSpeed = 8.0f;
    public int  maxJump = 1;
    public int[] attackRange = new int[6];
    public int maxHP = 100;

    [Header("特殊能力")]
    public bool barrier = false;

    void Awake()
    {
        Instance = this;
        health = GetComponent<MainCharaHealth>();
        
    }

    public void AddMaxHP(int value)
    {
        maxHP += value;
        health.heal();
        if (health.barrierCount >= 1)
        {
            health.barrierCount = 0;
            barrier = true;
        }
    }
}