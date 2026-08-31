using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharaHealth : MonoBehaviour
{
    [SerializeField] private int maxHp = 3;

    private int currentHp;
    public float mutekijikan;
    private float mutekitimer = 0f;
    public int touchdamage;
    Rigidbody2D rigidbody2d;

    private void Awake()
    {
        currentHp = maxHp;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        Debug.Log($"{gameObject.name} が {damage} ダメージを受けた。残りHP: {currentHp}");

        if (currentHp <= 0)
        {
            Die();
        }
    }

    void Start(){
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    void Update(){
        if (mutekitimer > 0){
            mutekitimer -= Time.deltaTime;
        }
    }
    void OnTriggerStay2D(Collider2D other){
        if (other.CompareTag("Enemy") && mutekitimer <= 0){
            TakeDamage(touchdamage);
            mutekitimer = mutekijikan;
        }
        
    }
}