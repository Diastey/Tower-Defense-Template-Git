using UnityEngine;

[CreateAssetMenu(fileName = "FlagCheck", menuName = "States/CheckCondition/FlagCheck")]
public class FlagCheck : CheckCondition
{
    public FlagDefinition flagToCheck;
    public override bool RunStateConditionCheck(StateMachine stateMachine)
    {
        return stateMachine.stateManager.runtimeFlags[flagToCheck.GetDataIdentifierID()]
            == neededStatus;
    }
}
