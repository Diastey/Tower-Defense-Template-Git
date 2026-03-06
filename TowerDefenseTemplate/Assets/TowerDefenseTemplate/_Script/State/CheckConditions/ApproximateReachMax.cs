using UnityEngine;

[CreateAssetMenu(fileName = "ApproximateReachMax", menuName = "States/CheckCondition/ApproximateReachMax")]
public class ApproximateReachMax : CheckCondition
{
    public StatDefinition statToCheck;
    public override bool RunStateConditionCheck(StateMachine stateMachine)
    {
        return Mathf.Approximately(stateMachine.stateManager.GetStatsByIdentifierID(statToCheck.GetDataIdentifierID()).currentValue,
            stateMachine.stateManager.GetStatsByIdentifierID(statToCheck.GetDataIdentifierID()).maxValue)
            == neededStatus;
    }
}
