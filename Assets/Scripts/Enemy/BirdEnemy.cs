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
    public bool 
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
            }
        }
        else
        {
            Charge();
        }
    }

    void Patrol()
    {
        startPos += Vector3.right * speed * Time.deltaTime;
        
        startPos = Mathf.Clamp(startPos + Vector3.right * speed * Time.deltaTime, leftlim, rightlim);

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
    }
}