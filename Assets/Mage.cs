using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mage : MonoBehaviour
{
    public Animator _anim;
    public NavMeshAgent _agen;
    public List<Transform> _puntoPatrullaje;
    public Transform _detecpivot;
    public GameObject _player;
    public LayerMask detecLayer;
    public float _distance;
    public float _maximaDistanciAtaque;
    public float _detecRadio;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _agen = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (_distance <= _maximaDistanciAtaque)
        {
            _anim.SetBool("ataque", true);
        }
        else
        {
            _anim.SetBool("ataque", false);
        }
    }

    void FixedUpdate()
    {
        Collider[] col = Physics.OverlapSphere(_detecpivot.position, _detecRadio, detecLayer);
        if (col.Length > 0)
        {
            _player = col[0].gameObject;
            _distance = Vector3.Distance(transform.position, _player.transform.position);
            _anim.SetBool("DetectoJugador", true);
            Debug.Log("Detecté jugador: " + _player.name);
        }
        else
        {
            _player = null;
            _distance = Mathf.Infinity;
            _anim.SetBool("DetectoJugador", false);
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