using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpliteFlip : MonoBehaviour
{
    Move move;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Move>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.flipX = !move.FacingRight;
    }
}
