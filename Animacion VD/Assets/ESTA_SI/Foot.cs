using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public static class Foot 
{
    [DrawGizmo(GizmoType.Active | GizmoType.NonSelected, typeof(Walk))]
    public static void DrawGizmos(Component component, GizmoType gizmoType)

    {
        Walk target = component as Walk;
        if (target == null) return;
        Gizmos.color = target.HasTarget ? Color.green : Color.red;
        Vector3 detectionStartPosition = target.GetDetectionStartPosition();
        Gizmos.DrawSphere(target.GetDetectionStartPosition(), 0.1f);
        Handles.Label(target.GetDetectionStartPosition(), "punto de detec");

    }
}
