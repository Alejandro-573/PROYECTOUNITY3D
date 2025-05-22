using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using UnityEngine.InputSystem.XR;

public class Rogue : MonoBehaviour
{
    Animator _anim;
    NavMeshAgent _agent;

    [SerializeField] List<Transform> _patrolPositions;


    [SerializeField] Transform detectionPivot;
    [SerializeField] float detectionRadius;
    [SerializeField] LayerMask detectionLayers;


    [SerializeField] GameObject _playerGO;
    [SerializeField] float _distance;
    [SerializeField] float maxDistanceToAttack;


    public NavMeshAgent Agent { get => _agent; set => _agent = value; }
    public Animator Anim { get => _anim; set => _anim = value; }
    public List<Transform> PatrolPositions { get => _patrolPositions; set => _patrolPositions = value; }
    public GameObject PlayerGO { get => _playerGO; set => _playerGO = value; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();

        Aleatorio();
    }

    // Update is called once per frame
    void Update()
    {
        if (_distance <= maxDistanceToAttack)
        {
            Anim.SetBool("Attack", true);
        }
        else
        {
            Anim.SetBool("Attack", false);
        }
    }

    private void FixedUpdate()
    {
        Collider[] collisions = Physics.OverlapSphere(detectionPivot.position, detectionRadius, detectionLayers);

        if (collisions.Length > 0)
        {
            _playerGO = collisions[0].gameObject;
            _distance = Vector3.Distance(transform.position, PlayerGO.transform.position);
        }
        else
        {
            _playerGO = null;
        }

        Anim.SetBool("PlayerDetected", _playerGO);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(detectionPivot.position, detectionRadius);
    }

    public void Aleatorio()
    {
        List<int> numeros = new List<int>()
        {
            6,7,9,10,13,16,23,25,26,28,29,30,19,8,11,14,15, 21,20,22,12
        };

        for (int i = 0; i < 1; i++)
        {
            int random = Random.Range(6, 32);

            if (numeros.Contains(random))
            {
                i--;
            }
            else
            {
                Debug.Log("Victima:" + random);
                numeros.Add(random);
            }
        }
    }
}
