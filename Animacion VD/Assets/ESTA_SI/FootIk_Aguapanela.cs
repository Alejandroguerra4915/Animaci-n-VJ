using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FootIk_Aguapanela : MonoBehaviour
{
    [SerializeField] private Transform detectionReference; //Caderas
    [SerializeField] private Transform foot; //Pie
    [SerializeField][Range(0, 1)] private float detectionRange;//interpolante para punto intermedio entre cadera y pie con ejes x,z en 0s
    [SerializeField] private float maxDetectionDistance; //Maximo rango de rayo para detectar superficies
    [SerializeField] private AvatarIKGoal ikGoal;

    private Animator animator;

    private bool hasTarget;
    private RaycastHit ikTarget;

    /// <summary>
    /// Obtener el punto inicial desde el cual se lanzara el rayo para detectar superficies
    /// </summary>
    /// <returns></returns>
    public Vector3 GetDetectionStartPosition()
    {
        Vector3 referenceSpacePosition = detectionReference.InverseTransformPoint(foot.position);
        Vector3 ret = new Vector3(referenceSpacePosition.x, referenceSpacePosition.y * detectionRange, referenceSpacePosition.z);
        return detectionReference.TransformPoint(ret);
    }

    /// <summary>
    /// Detectar y actualizar posiciones emnm superficies que intersecten con el rayo
    /// </summary>
    private bool GetTargetPosition()
    {
        return Physics.Raycast(GetDetectionStartPosition(), -detectionReference.up, out ikTarget, maxDetectionDistance);
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Detectar superficies, TODO: aplicar posiciones a huesos ik
    /// </summary>
    /// <param name="layerIndex"></param>
    private void OnAnimatorIK(int layerIndex)
    {
        hasTarget = GetTargetPosition();
        animator.SetIKPositionWeight(ikGoal, 1.0f);
        animator.SetIKPosition(ikGoal, ikTarget.point);
    }

    public Transform DetectionReference => detectionReference;
    public float MaxDetectionDistance => maxDetectionDistance;

    public bool HasTarget => hasTarget;
}