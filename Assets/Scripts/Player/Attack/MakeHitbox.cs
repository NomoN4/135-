using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeHitbox : MonoBehaviour
{
    int attacktype;
    int preattacktype = 1;
    public float[] xOffsets; //キャラクターの座標+この値の位置に攻撃判定を出す.６こ値持つ。
    public float[] AttackFrame; //攻撃判定がでるフレーム
    public float[] ActiveFrame; //全体フレーム
    public bool isAttacking = false;
    public GameObject[] hitboxPrefabs;
    public float FPS = 60f;
    float Freezetimer = 0f; //攻撃中動けなくするためのタイマー
    Move move;
    // Start is called before the first frame update
    int GenerateRandom1to6()
    {
        return Random.Range(1, 7);
    }
    void Start()
    {
        attacktype = GenerateRandom1to6();
        move = GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Freezetimer > ActiveFrame[preattacktype - 1] / FPS && move.Canmove == false)
        {
            move.Canmove = true;
            Freezetimer = 0f;
        }
        else if(move.Canmove == false)
        {
            Freezetimer += Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0) && move.Canmove)
        {
            move.Canmove = false;
            Freezetimer = 0f;
            Vector3 pos = transform.position;
            if (move.FacingRight)
                pos.x += xOffsets[attacktype - 1];
            else
                pos.x -= xOffsets[attacktype - 1];

            GameObject hitbox = Instantiate(
                hitboxPrefabs[attacktype - 1],
                pos,
                Quaternion.identity
            );
            Destroy(hitbox, AttackFrame[attacktype - 1] / FPS);
            
            preattacktype = attacktype;
            attacktype = GenerateRandom1to6();
            
        }
    }
}
