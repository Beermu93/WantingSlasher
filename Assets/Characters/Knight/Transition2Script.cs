using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition2Script : StateMachineBehaviour
{
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Knight_Controller.instance.isAttacking)
        {
            Knight_Controller.instance.knightAnim.Play("Knight_Attack_3");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Knight_Controller.instance.isAttacking = false;
    }
}
