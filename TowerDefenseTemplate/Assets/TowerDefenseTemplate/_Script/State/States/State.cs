using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewState", menuName = "States/NewState")]
public class State : BaseData, IState
{
    public List<StateBehaviour> enterBehaviours;
    public List<StateBehaviour> exitBehaviours;

    public List<StateBehaviour> updateBehaviours;
    public List<StateTransitionCheck> transitionChecks;

    public void OnEnter(StateMachine stateMachine)
    {
        for (int i = 0; i < enterBehaviours.Count; i++)
        {
            enterBehaviours[i].RunStateBehaviour(stateMachine);
        }
    }
    public void OnExit(StateMachine stateMachine)
    {
        for (int i = 0; i < exitBehaviours.Count; i++)
        {
            exitBehaviours[i].RunStateBehaviour(stateMachine);
        }
    }
    public void FramesUpdate(StateMachine stateMachine)
    {
        OnCheck(stateMachine);

        for (int i = 0; i < updateBehaviours.Count; i++)
        {
            updateBehaviours[i].RunStateBehaviour(stateMachine);
        }
    }
    //public void PhysicsUpdate(StateManagers stateManager, StateMachine stateMachine) { }

    public void OnCheck(StateMachine stateMachine)
    {
        for (int i = 0; i < transitionChecks.Count; i++)
        {
            if (transitionChecks[i].RunTransitionCheck(stateMachine))
            {
                stateMachine.ChangeState(transitionChecks[i].GetTransitionStateID());
                break;
            }
        }
    }
}
