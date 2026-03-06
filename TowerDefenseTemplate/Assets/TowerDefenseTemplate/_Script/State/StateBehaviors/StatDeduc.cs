using UnityEngine;

[CreateAssetMenu(fileName = "DeducStat", menuName = "States/NewBehaviour/DeducStat")]
public class StatDeduc : StateBehaviour
{
    public StatDefinition deducStat;
    public StatDefinition deducAmountStat;
    public override void RunStateBehaviour(StateMachine stateMachine)
    {
        stateMachine.stateManager.GetStatsByIdentifierID(deducStat.GetDataIdentifierID())
            .Modify(-stateMachine.stateManager.GetStatsByIdentifierID(deducAmountStat.GetDataIdentifierID()).currentValue);
    }
}
