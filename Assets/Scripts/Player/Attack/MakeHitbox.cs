using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeHitbox : MonoBehaviour
{
    int attacktype;
    public float[] xOffsets; //キャラクターの座標+この値の位置に攻撃判定を出す.６こ値持つ。
    public float[] ActiveFrame; //全体フレーム 
    public GameObject[] hitboxPrefabs;
    public float FPS = 60f;
    // Start is called before the first frame update
    int GenerateRandom1to6()
    {
        return Random.Range(1, 7);
    }
    void Start()
    {
        attacktype = GenerateRandom1to6();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Move move = GetComponent<Move>();
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
            Destroy(hitbox, ActiveFrame[attacktype - 1] / FPS);

            attacktype = GenerateRandom1to6();
        }
    }
}
