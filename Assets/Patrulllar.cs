using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrulllar : StateMachineBehaviour
{
    Mage controller;

    private int posicionActual=0;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateinfo, int layerindex)
    {
        controller=animator.GetComponent<Mage>();
        controller.Agen.stoppingDistance = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(controller.Agen.hasPath && controller.Agen.remainingDistance < 0.1f)
        { 
            posicionActual++;

            if (posicionActual >= controller._puntoPatrullaje.Count)
            {
                posicionActual = 0;
            }
        }
        controller.Agen.SetDestination(controller._puntoPatrullaje[posicionActual].position);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
}
