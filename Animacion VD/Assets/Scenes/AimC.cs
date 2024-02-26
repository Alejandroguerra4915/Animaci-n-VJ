using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(AimConstraint))]
public class AimC : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private AimConstraint constraint;
    private int aimWeightID;
    public void Awake()
    {
        constraint = GetComponent<AimConstraint>();
        aimWeightID = Animator.StringToHash("AimW");
        

    }

    private void LateUpdate()
    {
        constraint.weight = animator.GetFloat("AimW");
    }
}
