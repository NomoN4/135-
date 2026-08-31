using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    Status playerStatus = Status.GROUND;

    public float firstSpeed = 16.0f;
    public float gravity = 120.0f;

    public int maxJumpCount = 2; // 最大ジャンプ回数
    private int jumpCount = 0;   // 現在のジャンプ回数

    float timer = 0f;
    bool jumpKey = false;

    enum Status
    {
        GROUND = 1,
        UP = 2,
    }

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCount < maxJumpCount)
            {
                jumpKey = true;
                playerStatus = Status.UP;
                jumpCount++;
                rigidbody2d.velocity = new Vector2(
                    rigidbody2d.velocity.x,
                    rigidbody2d.velocity.y + firstSpeed
                );
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerStatus = Status.GROUND;
            jumpKey = false;
            timer = 0f;
            jumpCount = 0; // ジャンプ回数リセット
        }

        Debug.Log("Hit : " + collision.gameObject.name);
    }

}