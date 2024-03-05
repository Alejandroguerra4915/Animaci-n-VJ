using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    [SerializeField] private Transform detectionReference;
    [SerializeField] private Transform foot;
    [SerializeField][Range(0, 1)] private float detectionrange;
    [SerializeField] private float maxDetectionDistance;

    private bool hasTarget;
    private RaycastHit ikTarget;
    public Vector3 GetDetectionStartPosition()
    {
        Vector3 referenceSpacePosition = detectionReference.InverseTransformPoint(foot.position);
        Vector3 ret = new Vector3(referenceSpacePosition.x, referenceSpacePosition.y * detectionrange, referenceSpacePosition.z);
        return detectionReference.TransformPoint(ret);
    }

    private void GetTargetPosition()
    {
        hasTarget = Physics.Raycast(GetDetectionStartPosition(), -detectionReference.up, out ikTarget, maxDetectionDistance);
    }

    private void OnAnimatorIK(int layerIndex)
    {
        GetTargetPosition();
    }

    public Transform DetectionReference => detectionReference;
    public float MaxDetectionDistance => maxDetectionDistance;

    public bool HasTarget => HasTarget;
}
