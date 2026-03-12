using System;
using System.Collections.Generic;

[Serializable]
public class StateTransitionCheck : IStateTransitionCheck
{
    public State transitionState;
    public List<CheckCondition> checkConditions;
    public bool RunTransitionCheck(StateMachine stateMachine)
    {
        int conditionCheckCount = 0;
        for (int i = 0; i < checkConditions.Count; i++)
        {
            if (checkConditions[i].RunStateConditionCheck(stateMachine))
            {
                conditionCheckCount++;
            }
            else
            {
                return false;
            }
        }

        return conditionCheckCount == checkConditions.Count;
    }

    public int GetTransitionStateID()
    {
        return transitionState.GetDataID();
    }
}
