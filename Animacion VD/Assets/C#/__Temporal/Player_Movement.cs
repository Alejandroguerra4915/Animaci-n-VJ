using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{

    CharacterController characterController;
    Transform cam;

    float speedSmoothVelocity;
    float speedSmoothTime;
    float currentSpeed;
    float velocityY;
    Vector3 moveInput;
    Vector3 dir;

    [SerializeField] float gravity = 25f;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float rotateSpeed = 3f;
    [SerializeField] Animator animator;
    bool _lock = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        playerRotation();

        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            if (_lock) 
            {
                _lock = false;
                animator.Play("FreeLook");
            }
            else 
            {
                _lock = true;
                animator.Play("Lock");
            }
        }

    }

    public void GetInpur(InputAction.CallbackContext context) 
    {
        Vector2 Input = context.ReadValue<Vector2>();

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        moveInput = (right * Input.x + forward * Input.y).normalized;
    }

    private void Move() 
    {
        transform.position += moveInput * moveSpeed * Time.deltaTime;
    }

    private void playerRotation() 
    {
        float angle = Mathf.Atan2(moveInput.x, moveInput.z) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
