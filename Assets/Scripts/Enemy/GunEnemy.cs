using System.Collections;
using UnityEngine;

public class GunEnemy : MonoBehaviour
{
    [Header("対象")]
    public Transform player;

    [Header("射撃設定")]
    public float aimTime = 2.0f;       // 照準する時間
    public float flashTime = 0.8f;     // 射線が点滅する時間
    public float shotInterval = 1.0f;  // 次の射撃まで

    [Header("射線")]
    public LineRenderer aimLine;       // 赤い照準線

    [Header("発射")]
    public LineRenderer shotLine;      // 白い光線
    public float shotLength = 20f;
    public float shotDuration = 0.1f;

    private Vector2 targetPosition;

    void Start()
    {
        StartCoroutine(ShootLoop());
        aimLine.positionCount = 2;
        shotLine.positionCount = 2;
    }

    IEnumerator ShootLoop()
    {
        while (true)
        {
            // -------------------------
            // ① プレイヤーを狙い続ける
            // -------------------------

            float timer = 0f;

            while (timer < aimTime)
            {
                if (player != null)
                {
                    aimLine.enabled = true;

                    aimLine.SetPosition(0, transform.position);
                    Debug.Log("aaa");
                    aimLine.SetPosition(1, player.position);
                }

                timer += Time.deltaTime;
                yield return null;
            }

            // -------------------------
            // ② プレイヤーの位置を固定
            // -------------------------

            targetPosition = player.position;

            Vector2 direction =
                (targetPosition - (Vector2)transform.position).normalized;

            Vector2 endPosition =
                (Vector2)transform.position + direction * shotLength;

            // -------------------------
            // ③ 赤い射線を点滅
            // -------------------------

            float flashTimer = 0f;
            bool visible = true;

            while (flashTimer < flashTime)
            {
                visible = !visible;
                aimLine.enabled = visible;

                aimLine.SetPosition(0, transform.position);
                aimLine.SetPosition(1, endPosition);

                yield return new WaitForSeconds(0.1f);

                flashTimer += 0.1f;
            }

            aimLine.enabled = false;

            // -------------------------
            // ④ 白い光線を発射
            // -------------------------

            shotLine.enabled = true;

            shotLine.SetPosition(0, transform.position);
            shotLine.SetPosition(1, endPosition);

            yield return new WaitForSeconds(shotDuration);

            shotLine.enabled = false;

            // -------------------------
            // ⑤ 少し待つ
            // -------------------------

            yield return new WaitForSeconds(shotInterval);
        }
    }
}