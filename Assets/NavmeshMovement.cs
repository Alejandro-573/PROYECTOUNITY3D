using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;
    Rigidbody rigid;

    private void OnEnable()
    {
        InputController.Instance.CollisionDetectedEvent += SetTargetPosition;
    }

    private void OnDisable()
    {
        InputController.Instance.CollisionDetectedEvent -= SetTargetPosition;
    }

    public void SetTargetPosition(RaycastHit hit)
    {
        target.position = hit.point;
    }
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (agent.enabled)
            agent.SetDestination(target.position);
    }

    public void Jump(Vector3 force)
    {
        DisableAgentMovement();
        rigid.AddForce(force, ForceMode.Impulse);
    }

    public bool NeedActivation()
    {
        return !agent.enabled;
    }

    public void EnableAgentMovement()
    {
        if (!agent.enabled)
        {
            rigid.constraints = RigidbodyConstraints.FreezeAll;
            agent.enabled = true;
        }
    }

    public void DisableAgentMovement()
    {
        rigid.constraints = RigidbodyConstraints.FreezeRotationX
            | RigidbodyConstraints.FreezeRotationZ;
        agent.enabled = false;
    }
}
