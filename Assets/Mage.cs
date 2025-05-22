using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mage : MonoBehaviour
{
    private Animator anim;
    private NavMeshAgent agen;
    public List<Transform> _puntoPatrullaje;
    public Transform _detecpivot;
    private GameObject player;
    public LayerMask detecLayer;
    public float _distance;
    public float _maximaDistanciAtaque;
    public float _detecRadio;

    public Animator Anim { get => anim; set => anim = value; }
    public NavMeshAgent Agen { get => agen; set => agen = value; }
    public object Agent { get; internal set; }
    public GameObject Player { get => player; set => player = value; }

    void Start()
    {
        Anim = GetComponent<Animator>();
        Agen = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (_distance >= _maximaDistanciAtaque)
        {
            Anim.SetBool("ataque", true);
        }
        else
        {
            Anim.SetBool("ataque", false);
        }
    }

    void FixedUpdate()
    {
        Collider[] col = Physics.OverlapSphere(_detecpivot.position, _detecRadio, detecLayer);
        if (col.Length > 0)
        {
            Player = col[0].gameObject;
            _distance = Vector3.Distance(transform.position, Player.transform.position);
            Anim.SetBool("DetectoJugador", true);
            Debug.Log("Detecté jugador: " + Player.name);
        }
        else
        {
            Player = null;
            _distance = Mathf.Infinity;
            Anim.SetBool("DetectoJugador", false);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (_detecpivot != null)
        {
            Gizmos.DrawWireSphere(_detecpivot.position, _detecRadio);
        }
    }
}