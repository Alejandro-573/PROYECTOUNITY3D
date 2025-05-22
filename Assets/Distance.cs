using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huida : StateMachineBehaviour
{
    Mage controller;

    public float escapeDistance = 6f;
    public float hysteresisMargin = 5f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller = animator.GetComponent<Mage>();
        controller.Agen.stoppingDistance = 0;

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (controller.Player == null)
        {
            animator.SetBool("Huida", false);
            return;
        }

        Vector3 directionAway = (controller.transform.position - controller.Player.transform.position).normalized;
        Vector3 targetPosition = controller.transform.position + directionAway * escapeDistance;

        controller.Agen.SetDestination(targetPosition);

        float distance = Vector3.Distance(controller.transform.position, controller.Player.transform.position);

        
        if (distance >= controller._maximaDistanciAtaque + hysteresisMargin)
        {
            animator.SetBool("Huida", false);
            animator.SetBool("Escapar", true);  
        }
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
