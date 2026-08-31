using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;
    public float x = 3;
    public float leftlim = -10;
    public float rightlim = 10;

    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(
            Mathf.Clamp(target.position.x - x, leftlim, rightlim),
            transform.position.y, // Y固定
            transform.position.z
        );

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            smoothSpeed * Time.deltaTime
        );
    }
}