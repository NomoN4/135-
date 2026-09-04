using System.Collections;
using UnityEngine;

public class GunEnemy : MonoBehaviour
{
    [Header("対象")]
    public Transform player;

    [Header("照準")]
    public float aimTime = 2.0f;

    [Header("点滅")]
    public float flashTime = 0.8f;
    public float flashInterval = 0.1f;

    [Header("レーザー")]
    public float shotLength = 20f;
    public float shotDuration = 0.1f;
    public float shotInterval = 1.0f;

    [Header("LineRenderer")]
    public LineRenderer aimLine;
    public LineRenderer shotLine;

    public int damage;


    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (player.position.x > transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }

        aimLine.positionCount = 2;
        shotLine.positionCount = 2;

        aimLine.enabled = false;
        shotLine.enabled = false;

        StartCoroutine(ShootLoop());
    }
    private void Update()
    {
        if (player != null)
        {
            if (player.position.x > transform.position.x)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }

            aimLine.SetPosition(0, transform.position);
            aimLine.SetPosition(1, player.position);
        }
    }


    IEnumerator ShootLoop()
    {
        while (true)
        {
            // =================================
            // ① プレイヤーを追いかけて照準
            // =================================

            float timer = 0f;

            aimLine.enabled = true;

            while (timer < aimTime)
            {
                if (player != null)
                {
                    aimLine.SetPosition(0, transform.position);
                    aimLine.SetPosition(1, player.position);
                }

                timer += Time.deltaTime;

                yield return null;
            }


            // =================================
            // ② プレイヤーの位置を記録
            // =================================

            Vector2 targetPosition = player.position;

            Vector2 direction =
                (targetPosition - (Vector2)transform.position).normalized;

            Vector2 endPosition =
                (Vector2)transform.position
                + direction * shotLength;


            // =================================
            // ③ 赤い照準線を点滅
            // =================================

            float flashTimer = 0f;

            while (flashTimer < flashTime)
            {
                aimLine.enabled = !aimLine.enabled;

                aimLine.SetPosition(0, transform.position);
                aimLine.SetPosition(1, endPosition);

                yield return new WaitForSeconds(flashInterval);

                flashTimer += flashInterval;
            }

            aimLine.enabled = false;


            // =================================
            // ④ 白いレーザー発射
            // =================================

            shotLine.enabled = true;

            shotLine.SetPosition(0, transform.position);
            shotLine.SetPosition(1, endPosition);


            // =================================
            // ⑤ レーザーの当たり判定
            // =================================

            RaycastHit2D[] hits = Physics2D.RaycastAll(
                transform.position,
                direction,
                shotLength
            );

            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider.CompareTag("Player"))
                {
                    MainCharaHealth health =
                        hit.collider.GetComponent<MainCharaHealth>();

                    if (health != null)
                    {
                        health.TakeDamage(damage);
                    }

                    break;
                }
            }


            // レーザー表示
            yield return new WaitForSeconds(shotDuration);

            shotLine.enabled = false;


            // =================================
            // ⑥ 次の攻撃まで待つ
            // =================================

            yield return new WaitForSeconds(shotInterval);
        }
    }
}