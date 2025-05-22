using UnityEngine;
//using UnityEngine.InputSystem.XR;

public class RoguePatrolState : StateMachineBehaviour
{
    Rogue controller;
    int currentPosition = 0;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controller = animator.GetComponent<Rogue>();
        controller.Agent.stoppingDistance = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (controller.Agent.hasPath && controller.Agent.remainingDistance < 0.1f)
        {
            currentPosition++;

            if (currentPosition >= controller.PatrolPositions.Count)
            {
                currentPosition = 0;
            }
        }

        controller.Agent.SetDestination(controller.PatrolPositions[currentPosition].position);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

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
