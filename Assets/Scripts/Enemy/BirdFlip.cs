using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlip : MonoBehaviour
{
    BirdEnemy birdenemy;
    private SpriteRenderer spriteRenderer;
    private bool flip = false;
    // Start is called before the first frame update
    void Start()
    {
        birdenemy = GetComponent<BirdEnemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(birdenemy.GoRight == 1){
            flip = true;
        }
        else{
            flip = false;
        }
        //Debug.Log(flip);
        spriteRenderer.flipX = flip;
    }
}
