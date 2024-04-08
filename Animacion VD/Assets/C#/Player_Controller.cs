using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public void OnMovement(InputAction.CallbackContext context) 
    {
        Vector2 movement = context.ReadValue<Vector2>();

        Debug.Log(movement);
        anim.SetFloat("X",movement.x);
        anim.SetFloat("Y",movement.y);
    }
}
