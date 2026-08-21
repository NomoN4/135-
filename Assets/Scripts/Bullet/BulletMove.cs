using UnityEngine;

public class HitboxMove : MonoBehaviour
{
    public float speed = 5.0f;
    private float direction = 1.0f;
    public Move move;

    void Start()
    {
        Debug.Log("HitboxMoveのmove = " + move);

        if (move == null)
        {
            Debug.LogError("moveがnull");
            return;
        }

        direction = move.FacingRight ? 1.0f : -1.0f;
    }
    void Update()
    {
        transform.position += Vector3.right * direction * speed * Time.deltaTime;
    }
}