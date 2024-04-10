using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{

    Transform cam;

    Vector3 moveInput;

    [SerializeField] float gravity = 25f;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float rotateSpeed = 3f;
    [SerializeField] Animator camera_Controller;
    [SerializeField] Animator character_Controller;
    bool _lock = false;

    private void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            if (_lock) 
            {
                _lock = false;
                camera_Controller.Play("FreeLook");
            }
            else 
            {
                _lock = true;
                camera_Controller.Play("Lock");
            }
        }

    }

    public void GetInpur(InputAction.CallbackContext context) 
    {
        Vector2 Input = context.ReadValue<Vector2>();

        playerRotation();

        character_Controller.SetFloat("X", Input.x);
        character_Controller.SetFloat("Y", Input.y);
    }

    /*public void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 movement = context.ReadValue<Vector2>();

        Debug.Log(movement);
        character_Controller.SetFloat("X", movement.x);
        character_Controller.SetFloat("Y", movement.y);
    }*/

    private void playerRotation() 
    {

        Vector3 forward = cam.forward;
        forward.y = 0f;
        transform.LookAt(forward*10);
    }
}
