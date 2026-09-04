using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainCharaHealth : MonoBehaviour
{
    private int currentHp;
    public float mutekijikan;
    public int EnemyBuff = 2;
    private float mutekitimer = 0f;
    public int touchdamage;
    public int barrierCount = 0;
    Rigidbody2D rigidbody2d;
    DamageFlash damageflash;
    [SerializeField] private TMP_Text HPText;
    [SerializeField] private string loadScene;

    public void SceneChange()
    {
        SceneManager.LoadScene(loadScene);
    }

    public void heal()
    {
        currentHp = PlayerStats.Instance.maxHP;
        HPText.text = "HP:" + currentHp.ToString();
    }

    public void TakeDamage(int damage)
    {
        if (PlayerStats.Instance.barrier && barrierCount == 0)
        {
            barrierCount = 1;
            PlayerStats.Instance.barrier = false;
        }
        else
        {
            currentHp -= damage;

            Debug.Log($"{gameObject.name} が {damage} ダメージを受けた。残りHP: {currentHp}");
            HPText.text = "HP:" + currentHp.ToString();


            if (currentHp <= 0)
            {
                SceneChange();
            }
        }
        
    }

    void Start(){
        rigidbody2d = GetComponent<Rigidbody2D>();
        damageflash = GetComponent<DamageFlash>();
        currentHp = PlayerStats.Instance.maxHP;
        HPText.text = "HP:" + currentHp.ToString();
    }
    void Update(){
        if (mutekitimer > 0){
            mutekitimer -= Time.deltaTime;
        }
    }
    void OnTriggerStay2D(Collider2D other){
        if (other.CompareTag("Enemy") && mutekitimer <= 0){
            TakeDamage(touchdamage + GameManager.Instance.floor * EnemyBuff);
            damageflash.Flash();
            mutekitimer = mutekijikan;
        }
        
    }
}