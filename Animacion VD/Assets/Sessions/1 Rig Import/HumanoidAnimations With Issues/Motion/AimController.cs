using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ThirdPersonShooter;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

[RequireComponent(typeof(Animator))]

public class AimController : ThirdPersonShooterPlayerScript
{
    [SerializeField] private Transform cameraRotationTarget;
    [SerializeField] private float lookSpeed = 30;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Look(InputAction.CallbackContext context)
    {
        Vector2 inputValue = context.ReadValue<Vector2>();
        if (cameraRotationTarget == null) return;

        cameraRotationTarget.RotateAround(transform.position, transform.up, inputValue.x * lookSpeed * Time.deltaTime);
    }

    public void ToogleAim(InputAction.CallbackContext context) 
    {
        float inputValues = context.ReadValue<float>();
        animator.SetBool("ToogleAim", inputValues>0);
        //playerData.State = inputValues > 0 ? ThirdPersonShooterPlayerData.PlayerState.AimingMode : ThirdPersonShooterPlayerData.PlayerState.NormalMode;
    }

    //protected override void OnStateChanged(ThirdPersonShooterPlayerData.PlayerState state)
    //{
    //    //animator.SetBool("ToogleAim", state == ThirdPersonShooterPlayerData.PlayerState.AimingMode);
    //}
}
