using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{
    public float speed = 3.0f;
    Rigidbody2D rigidbody2d;
    float horizontalInput;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 水平方向の入力（左右キー）
        horizontalInput = Input.GetAxisRaw("Horizontal");

    }
    void FixedUpdate()
    {
        // x方向だけ変更し、ジャンプ側が設定した y速度は残す
        rigidbody2d.velocity = new Vector2(
            horizontalInput * speed,
            rigidbody2d.velocity.y
        );
    }

}
