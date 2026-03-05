using UnityEngine;

[CreateAssetMenu(fileName = "CheckCondition", menuName = "Scriptable Objects/CheckCondition")]
public abstract class CheckCondition : BaseData, IStateConditionCheck
{
    public abstract bool RunStateConditionCheck(StateMachine stateMachine);
}
