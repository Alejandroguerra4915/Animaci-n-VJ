using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba_ATK : MonoBehaviour
{
    Animator anim;
    [SerializeField] bool ATK = false;
    bool weakSequence = false;
    bool strongSequence = false;
    int weak_ATK_Index = 0;
    int strong_ATK_Index = 0;
    [SerializeField] string[] ATK_Sequence_Weak;
    [SerializeField] string[] ATK_Sequence_Strong;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            Waek_Attack();
        }

        if(Input.GetKeyDown(KeyCode.R)) 
        {
            //Ulti
        }

        if (Input.GetKeyDown(KeyCode.E)) 
        {
            Strong_Attack();
        }
    }

    #region Weak ATK Sequence
    public void CheckForSequence() 
    {
        if (weakSequence) 
        {
            weakSequence = false;
            anim.Play(ATK_Sequence_Weak[weak_ATK_Index]);
            weak_ATK_Index++;
        }
    }

    private void Waek_Attack() 
    {
        if(!ATK) 
        {
            ATK = true;
            anim.Play(ATK_Sequence_Weak[weak_ATK_Index]);
            weak_ATK_Index++;
        }
        else 
        {
            weakSequence = true;
        }
    }

    public void End_Sequence() 
    {
        weak_ATK_Index = 0;
        weakSequence = false;
        ATK = false;
    }
    #endregion

    #region Strong ATK Sequience

    public void CheckForStrongSequence()
    {
        if (strongSequence)
        {
            strongSequence = false;
            anim.Play(ATK_Sequence_Strong[strong_ATK_Index]);
            strong_ATK_Index++;
        }
    }

    private void Strong_Attack()
    {
        if (!ATK)
        {
            ATK = true;
            anim.Play(ATK_Sequence_Strong[strong_ATK_Index]);
            strong_ATK_Index++;
        }
        else
        {
            strongSequence = true;
        }
    }

    public void End_Strong_Sequence()
    {
        strong_ATK_Index = 0;
        strongSequence = false;
        ATK = false;
    }

    #endregion
}
