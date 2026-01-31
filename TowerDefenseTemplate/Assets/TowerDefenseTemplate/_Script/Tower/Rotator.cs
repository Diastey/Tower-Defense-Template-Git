using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 currentTargetPoint;
    public Quaternion originalOrientation;
    public float rotationSpeed = 20f;
    public bool isRotating;

    private void Awake()
    {
        originalOrientation = transform.rotation;
    }

    private void Update()
    {
        if (isRotating)
            RotateToTarget();
        else
            ResetRotation();
    }

    private void RotateToTarget()
    {
        Vector3 targetPosition = currentTargetPoint;
        Vector3 targetDirection = (targetPosition - transform.position).normalized;
        //Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0.0f);

        Quaternion newRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
    }

    private void ResetRotation()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, originalOrientation, rotationSpeed * Time.deltaTime);
    }
}
