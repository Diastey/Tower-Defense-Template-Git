using UnityEngine;

[CreateAssetMenu(fileName = "StatRegeneration", menuName = "States/NewBehaviour/StatRegeneration")]
public class StatRegeneration : StateBehaviour
{
    public StatDefinition regenStat;
    public StatDefinition regenRateStat;
    public override void RunStateBehaviour(StateMachine stateMachine)
    {
        stateMachine.stateManager.GetStatsByIdentifierID(regenStat.GetDataIdentifierID())
            .Modify(Time.deltaTime * stateMachine.stateManager.GetStatsByIdentifierID(regenRateStat.GetDataIdentifierID()).currentValue);
    }
}
