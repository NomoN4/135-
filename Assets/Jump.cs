using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    Status playerStatus = Status.GROUND; // プレイヤーの状態

    public float firstSpeed = 16.0f; // 初速
    public const float gravity = 120.0f; // 重力
    public const float jumpLowerLimit = 0.03f; // ジャンプ時間の下限

    float timer = 0f; // 経過時間
    bool jumpKey = false; // ジャンプキー
    bool keyLook = false; // キー入力を受け付けない

    enum Status
    {
        GROUND = 1,
        UP = 2,
        DOWN = 3
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (playerStatus == Status.DOWN && collision.gameObject.name.Contains("Ground"))
        {
            playerStatus = Status.GROUND;
        }
    }

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // キー入力取得
        if (Input.GetKey(KeyCode.Space))
        {
            jumpKey = !keyLook;
        }
        else
        {
            jumpKey = false;
            keyLook = false;
        }
    }

    void FixedUpdate()
    {
        Vector2 newvec = Vector2.zero;

        switch (playerStatus)
        {
            // 接地時
            case Status.GROUND:
                if (jumpKey)
                {
                    playerStatus = Status.UP;
                }
                break;

            // 上昇時
            case Status.UP:
                timer += Time.deltaTime;

                if (jumpKey || jumpLowerLimit > timer)
                {
                    newvec.y = firstSpeed;
                    newvec.y -= (gravity * Mathf.Pow(timer, 2));
                }

                else
                {
                    timer += Time.deltaTime; // 落下を早める
                    newvec.y = firstSpeed;
                    newvec.y -= (gravity * Mathf.Pow(timer, 2));
                }

                if (0f > newvec.y)
                {
                    playerStatus = Status.DOWN;
                    newvec.y = 0f;
                    timer = 0.1f;
                }
                break;

            // 落下時
            case Status.DOWN:
                timer += Time.deltaTime;

                newvec.y = 0f;
                newvec.y = -(gravity * Mathf.Pow(timer, 2));
                break;

            default:
                break;
        }

        rigidbody2d.velocity = newvec;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (playerStatus == Status.DOWN &&
            collision.gameObject.name.Contains("Ground"))
        {
            playerStatus = Status.GROUND;
            timer = 0f;
            keyLook = true; // キー操作をロックする
        }
    }
}

