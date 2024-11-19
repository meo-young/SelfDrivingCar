using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 moveOffset;

    public Transform carTarget;

    private void FixedUpdate()
    {
        Followtarget();
    }
    void Followtarget()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        Vector3 targetPos = new Vector3();
        targetPos = carTarget.TransformPoint(moveOffset);

        transform.position = targetPos;
    }
}
