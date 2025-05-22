using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retroceder : StateMachineBehaviour
{
        private Mage controller;
        private Vector3 puntoRetirada;
        private bool llego;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Entrando a estado RETROCEDER");
        controller = animator.GetComponent<Mage>();
        llego = false;

        if (controller._player == null) return;

        Vector3 dir = (controller.transform.position - controller._player.transform.position).normalized;
        puntoRetirada = controller.transform.position + dir * 5f;

        controller._agen.stoppingDistance = 0;
        controller._agen.SetDestination(puntoRetirada);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (!llego && !controller._agen.pathPending && controller._agen.remainingDistance <= controller._agen.stoppingDistance + 0.1f)
            {
                llego = true;
                animator.SetBool("RetrocesoListo", true);
            }
        }

        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("RetrocesoListo", false);
        }
}


    

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
