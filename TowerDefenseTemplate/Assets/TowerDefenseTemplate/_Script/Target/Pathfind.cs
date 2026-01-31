using UnityEngine;

[RequireComponent(typeof(Rotator))]
public class Pathfind : MonoBehaviour
{
    public PathToFind path;
    public Rotator rotator;
    public Vector3 currentDestination;
    public int currentPointIndex;
    public float distanceThreshold = 0.1f;
    public float walkSpeed = 2f;

    private void Awake()
    {
        rotator = GetComponent<Rotator>();

        currentPointIndex = 0;
        currentDestination = path.pathPoints[currentPointIndex];
    }

    private void Update()
    {
        rotator.isRotating = true;
        rotator.currentTargetPoint = currentDestination;
        transform.position += transform.forward * walkSpeed * Time.deltaTime;

        ReachDestinationCheck();
    }

    private void ReachDestinationCheck()
    {
        if (Vector3.Distance(transform.position, currentDestination) <= distanceThreshold)
        {
            if (currentPointIndex + 1 >= path.pathPoints.Count)
            {
                currentPointIndex = 0;
            }
            else
            {
                currentPointIndex++;
            }
            currentDestination = path.pathPoints[currentPointIndex];
        }
    }
}
