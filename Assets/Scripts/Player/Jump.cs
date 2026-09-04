using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    public float firstSpeed = 16.0f;
    public float gravity = 120.0f;
    private int jumpCount = 0;   // 現在のジャンプ回数

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCount < PlayerStats.Instance.maxJump)
            {
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
            jumpCount = 0; // ジャンプ回数リセット
        }

        Debug.Log("Hit : " + collision.gameObject.name);
    }

}