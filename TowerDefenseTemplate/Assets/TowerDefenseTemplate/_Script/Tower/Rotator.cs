using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Detector detector;
    public Quaternion originalOrientation;
    public float rotationSpeed = 1f;
    public bool isRotating;

    private void Awake()
    {
        detector = GetComponent<Detector>();
        originalOrientation = transform.rotation;
    }

    private void Update()
    {
        if (detector.hasTarget)
            RotateToTarget();
        else
            ResetRotation();
    }

    private void RotateToTarget()
    {
        isRotating = true;
        Vector3 targetPosition = detector.currentTargetPoint;
        Vector3 targetDirection = (targetPosition - transform.position).normalized;
        //Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0.0f);

        Quaternion newRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
    }

    private void ResetRotation()
    {
        isRotating = false;

        transform.rotation = Quaternion.Slerp(transform.rotation, originalOrientation, rotationSpeed * Time.deltaTime);
    }
}
