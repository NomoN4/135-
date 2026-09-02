using System.Collections;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    private SpriteRenderer sr;

    public float flashInterval = 0.1f; // 点滅間隔
    public int flashCount = 3;         // 点滅回数

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Flash()
    {
        StartCoroutine(FlashCoroutine());
    }

    IEnumerator FlashCoroutine()
    {
        for (int i = 0; i < flashCount; i++)
        {
            sr.enabled = false;
            yield return new WaitForSeconds(flashInterval);

            sr.enabled = true;
            yield return new WaitForSeconds(flashInterval);
        }
    }
}