using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEnemy : MonoBehaviour
{
    public Transform player;

    [Header("Patrol")]
    public float speed = 3f;
    public float amplitude = 1f;
    public float frequency = 2f;
    public int GoRight = 1; //右が1,左が-1
    public float leftlim;
    public float rightlim;

    [Header("Charge")]
    public float detectDistance = 6f;
    public float chargeSpeed = 8f;

    private Vector3 startPos;
    private bool charging = false;
    private Vector2 chargeDirection;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (!charging)
        {
            Patrol();

            if (Vector2.Distance(transform.position, player.position) < detectDistance)
            {
                charging = true;
                chargeDirection = (player.position - transform.position).normalized;
                if(player.position.x - transform.position.x < 0){
                    GoRight = -1;
                    Debug.Log("左！");
                }
                else{
                    GoRight = 1;
                    Debug.Log("右！");
                }
            }
        }
        else
        {
            Charge();
        }
        Debug.Log(GoRight);
    }

    void Patrol()
    {
        if (transform.position.x > rightlim){
            GoRight = -1;
        }
        if (transform.position.x < leftlim){
            GoRight = 1;
        }
        startPos += Vector3.right * speed * Time.deltaTime * GoRight;
        
        startPos = startPos + Vector3.right * speed * Time.deltaTime;

        float y = Mathf.Sin(Time.time * frequency) * amplitude;

        transform.position = new Vector3(
            startPos.x,
            startPos.y + y,
            transform.position.z
        );
    }

    void Charge()
    {
        Vector2 dir = (player.position - transform.position).normalized;

        chargeDirection = Vector2.Lerp(
            chargeDirection,
            dir,
            2f * Time.deltaTime
        ).normalized;

        transform.position += (Vector3)chargeDirection * chargeSpeed * Time.deltaTime;
        if(player.position.x - transform.position.x < 0){
            GoRight = -1;
            Debug.Log("左！");
        }
        else{
            GoRight = 1;
            Debug.Log("右！");
        }
    }
}