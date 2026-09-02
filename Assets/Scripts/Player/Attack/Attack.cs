using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage = 3; //与えるダメージの量
    Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            DamageFlash damageflash = other.GetComponent<DamageFlash>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                damageflash.Flash();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
