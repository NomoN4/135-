using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float horizontalInput;
    public bool FacingRight = true;
    public bool Canmove = true;
    
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
        //Debug.Log(horizontalInput);
        if (horizontalInput > 0 && Canmove) FacingRight = true;
        else if (horizontalInput < 0) FacingRight = false;

    }
    void FixedUpdate()
    {
        // x方向だけ変更し、ジャンプ側が設定した y速度は残す
        if (Canmove)
        {
            rigidbody2d.velocity = new Vector2(
                horizontalInput * PlayerStats.Instance.moveSpeed,
                rigidbody2d.velocity.y
            );
        }
        else
        {
            rigidbody2d.velocity = new Vector2(
                0,
                rigidbody2d.velocity.y
            );
        }

    }

}
