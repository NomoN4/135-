using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    [Header("基本ステータス")]
    public  int attackPower = 0;
    public float moveSpeed = 8.0f;
    public int  maxJump = 1;
    public float attackRange = 1;
    public int maxHP = 100;

    [Header("特殊能力")]
    public bool barrier = false;

    void Awake()
    {
        Instance = this;
    }
}