using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ThirdPersonShooter;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class AimController : ThirdPersonShooterPlayerScript
{
    [SerializeField] private Transform cameraRotationTarget;

    public void Look(InputAction.CallbackContext context)
    {
        Vector2 inputValue = context.ReadValue<Vector2>();
        if (cameraRotationTarget == null) return;

        cameraRotationTarget.RotateAround(transform.position, transform.up, inputValue.x);
    }
}
