using System;
using UnityEngine;

[RequireComponent(typeof(Rotator))]
public class Detector : MonoBehaviour
{
    public GameObject currentTarget;
    public Vector3 currentTargetPoint;
    public float currentTargetDistance;
    public bool debugMode = true;

    [Space]
    public float detectRadius = 10f;
    public event Action<GameObject> OnChangeTarget;

    [Space]
    public bool hasTarget;

    private void OnEnable()
    {
        OnChangeTarget += DetectChangeTarget;
    }

    private void OnDisable()
    {
        OnChangeTarget -= DetectChangeTarget;
    }

    private void Update()
    {
        DetectTarget();
        UpdateTargetPosition();
    }
    private void DetectTarget()
    {
        GameObject bestTarget = null;
        float bestTargetDistance = float.MaxValue;

        Collider[] hit = Physics.OverlapSphere(transform.position, detectRadius);
        foreach (Collider col in hit)
        {
            if (col.gameObject.TryGetComponent<ITargetable>(out ITargetable targetable))
            {
                float distanceBetween = Vector3.Distance(col.transform.position, transform.position);
                if (distanceBetween < bestTargetDistance)
                {
                    bestTarget = col.gameObject;
                    bestTargetDistance = distanceBetween;
                }
            }
        }

        if (bestTarget != currentTarget)
            OnChangeTarget?.Invoke(bestTarget);

        hasTarget = currentTarget;

        GunManager.onToggleFire?.Invoke(hasTarget);
    }
    private void DetectTarget<T>()
    {
        GameObject bestTarget = null;
        float bestTargetDistance = float.MaxValue;

        Collider[] hit = Physics.OverlapSphere(transform.position, detectRadius);
        foreach (Collider col in hit)
        {
            if (col.gameObject.TryGetComponent<T>(out T targetable))
            {
                float distanceBetween = Vector3.Distance(col.transform.position, transform.position);
                if (distanceBetween < bestTargetDistance)
                {
                    bestTarget = col.gameObject;
                    bestTargetDistance = distanceBetween;
                }
            }
        }

        if (bestTarget != currentTarget)
            OnChangeTarget?.Invoke(bestTarget);

        hasTarget = currentTarget;

        GunManager.onToggleFire?.Invoke(hasTarget);
    }

    private void DetectChangeTarget(GameObject newTarget)
    {
        currentTarget = newTarget;
        if (currentTarget == null)
            return;

        currentTargetPoint = currentTarget.transform.position;
        currentTargetDistance = Vector3.Distance(transform.position, currentTargetPoint);
    }

    private void UpdateTargetPosition()
    {
        if (currentTarget == null)
            return;

        currentTargetPoint = currentTarget.transform.position;
        currentTargetDistance = Vector3.Distance(transform.position, currentTargetPoint);
    }

    private void OnDrawGizmos()
    {
        if (!debugMode) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, detectRadius);
    }
}
