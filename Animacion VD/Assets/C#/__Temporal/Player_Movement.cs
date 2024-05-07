using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{

    Transform cam;
    [SerializeField] Animator camera_Controller;
    [SerializeField] Animator character_Controller;
    bool _lock = false;

    bool ATK = false;
    bool weakSequence = false;
    bool strongSequence = false;
    int weak_ATK_Index = 0;
    int strong_ATK_Index = 0;
    [SerializeField] string[] ATK_Sequence_Weak;
    [SerializeField] string[] ATK_Sequence_Strong;

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
        if (ATK) return;

        Vector2 Input = context.ReadValue<Vector2>();

        playerRotation();

        character_Controller.SetFloat("X", Input.x);
        character_Controller.SetFloat("Y", Input.y);
    }

    private void playerRotation() 
    {
        float angle = Mathf.Atan2(cam.forward.x,cam.forward.z) * Mathf.Rad2Deg;

        Debug.Log(angle);
        transform.rotation = Quaternion.Euler(0,angle,0);
    }

    public void WeakATK(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Started) return;

        if (!ATK)
        {
            ATK = true;
            character_Controller.Play(ATK_Sequence_Weak[weak_ATK_Index]);
            weak_ATK_Index++;
        }
        else
        {
            weakSequence = true;
        }
    }

    public void Check_For_Weak_Sequence()
    {
        if (weakSequence)
        {
            weakSequence = false;
            character_Controller.Play(ATK_Sequence_Weak[weak_ATK_Index]);
            weak_ATK_Index++;
        }
    }

    public void End_Weak_Sequence()
    {
        weak_ATK_Index = 0;
        weakSequence = false;
        ATK = false;
    }

    public void StrongATK(InputAction.CallbackContext context)
    {
        if (context.phase != InputActionPhase.Started) return;

        if (!ATK)
        {
            ATK = true;
            character_Controller.Play(ATK_Sequence_Strong[strong_ATK_Index]);
            strong_ATK_Index++;
        }
        else
        {
            strongSequence = true;
        }
    }

    public void Check_For_Strong_Sequence()
    {
        if (strongSequence)
        {
            strongSequence = false;
            character_Controller.Play(ATK_Sequence_Strong[strong_ATK_Index]);
            strong_ATK_Index++;
        }
    }

    public void End_Strong_Sequence()
    {
        strong_ATK_Index = 0;
        strongSequence = false;
        ATK = false;
    }


}
