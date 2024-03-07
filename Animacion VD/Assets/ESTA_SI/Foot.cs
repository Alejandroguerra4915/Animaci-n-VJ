using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public static class Foot 
{
    [DrawGizmo(GizmoType.Active | GizmoType.NonSelected, typeof(FootIk_Aguapanela))]
    public static void DrawGizmos(Component component, GizmoType gizmoType)

    {
        
        FootIk_Aguapanela target = component as FootIk_Aguapanela;
        if (target == null) return;
        Gizmos.color = target.HasTarget ? Color.green : Color.red;
        Vector3 detectionStartPosition = target.GetDetectionStartPosition();
        Gizmos.DrawSphere(target.GetDetectionStartPosition(), 0.1f);
        Handles.Label(target.GetDetectionStartPosition(), "punto de detec");
    }
}
