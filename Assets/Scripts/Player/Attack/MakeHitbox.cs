using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeHitbox : MonoBehaviour
{
    int attacktype;
    int preattacktype = 1;
    public float[] diceWeight = { 1, 1, 1, 1, 1, 1 }; // omomi
    public float[] xOffsets; //キャラクターの座標+この値の位置に攻撃判定を出す.６こ値持つ。
    public float[] yOffsets; //キャラクターの座標+この値の位置に攻撃判定を出す.６こ値持つ。
    public float[] AttackFrame; //攻撃判定がでるフレーム
    public float[] ActiveFrame; //全体フレーム
    public bool isAttacking = false;
    public Sprite RunnningImage; //通常状態の画像
    public Sprite[] attackImage; //攻撃画像
    public GameObject[] hitboxPrefabs;
    public float FPS = 60f;
    float Freezetimer = 0f; //攻撃中動けなくするためのタイマー
    Move move;
    public DiceUI diceui;
    private SpriteRenderer spriteRenderer;

    public int RollDice()
    {
        float total = 0;

        for (int i = 0; i < diceWeight.Length; i++)
            total += diceWeight[i] + PlayerStats.Instance.attackRange[i];

        float rand = Random.Range(0f, total);

        float sum = 0;

        for (int i = 0; i < diceWeight.Length; i++)
        {
            sum += diceWeight[i] + PlayerStats.Instance.attackRange[i];

            if (rand <= sum)
                return i + 1;
        }

        return 6;
    }

    public void SetAttackImage(int attacktype)
    {
        // 1～6 → 配列の0～5
        int index = attacktype - 1;

        if (index < 0 || index >= 6)
        {
            Debug.LogError("攻撃番号が不正です: " + attacktype);
            return;
        }
        
        spriteRenderer.sprite = attackImage[index];
        return;
    }

    public void SetRunningImage()
    {
        spriteRenderer.sprite = RunnningImage;
    }
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        attacktype = RollDice();
        move = GetComponent<Move>();
        diceui.SetNumber(attacktype);
    }

    // Update is called once per frame
    void Update()
    {
        if (Freezetimer > ActiveFrame[preattacktype - 1] / FPS && move.Canmove == false)
        {
            move.Canmove = true;
            Freezetimer = 0f;
            SetRunningImage(); //画像を元に戻す
        }
        else if(move.Canmove == false)
        {
            Freezetimer += Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0) && move.Canmove)
        {
            move.Canmove = false;
            SetAttackImage(attacktype); //攻撃用の画像にする
            Freezetimer = 0f;
            Vector3 pos = transform.position;
            if (move.FacingRight)
                pos.x += xOffsets[attacktype - 1];
            else
                pos.x -= xOffsets[attacktype - 1];
            pos.y += yOffsets[attacktype - 1];


            GameObject hitbox = Instantiate(
                hitboxPrefabs[attacktype - 1],
                pos,
                Quaternion.identity
            );
            if(attacktype != 5)
            {
                hitbox.transform.SetParent(transform); // transformはプレイヤー
                if (move.FacingRight)
                {
                    hitbox.transform.localPosition = new Vector3(
                        1f + xOffsets[attacktype - 1],
                        0f + yOffsets[attacktype - 1],
                        0f); // プレイヤーからの距離
                }
                else
                {
                    hitbox.transform.localPosition = new Vector3(
                        -1f - xOffsets[attacktype - 1],
                        0f + yOffsets[attacktype - 1],
                        0f); // プレイヤーからの距離
                }
            }

            if (!move.FacingRight)
            {
                SpriteRenderer hitboxSprite = hitbox.GetComponent<SpriteRenderer>();

                if (hitboxSprite != null)
                {
                    hitboxSprite.flipX = true;
                }
            }

            BulletMove hitboxMove = hitbox.GetComponent<BulletMove>();

            if (hitboxMove != null)
            {
                hitboxMove.move = move;
            }
            Destroy(hitbox, AttackFrame[attacktype - 1] / FPS);
            
            preattacktype = attacktype;
            attacktype = RollDice();
            diceui.SetNumber(attacktype);
            
        }
    }
}
