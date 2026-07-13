using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;
    public float x = 3;

    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(
            target.position.x - x,
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