using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target and Offset")]
    [SerializeField] private Transform target;
    public Vector3 offset;
    [Header("Smooth Follow")]
    [SerializeField] private float smoothSpeed = 0.125f;

    private void LateUpdate()
    {
        if (target == null) return;
        
        Vector3 desirePosition = target.position + offset;
        
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desirePosition, smoothSpeed);
        
        transform.position = smoothedPosition;
    }
}
