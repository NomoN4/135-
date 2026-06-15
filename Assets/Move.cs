using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{
    public float speed = 3.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 水平方向の入力（左右キー）
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        
        // 移動量を計算
        Vector3 movement = new Vector3(horizontalInput, 0, 0) * speed * Time.deltaTime;

        // 位置を変更
        transform.position += movement;
    }
}
