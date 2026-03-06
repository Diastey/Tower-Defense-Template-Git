using UnityEngine;

//[CreateAssetMenu(fileName = "CheckCondition", menuName = "States/CheckCondition")]
public abstract class CheckCondition : BaseData, IStateConditionCheck
{
    public bool neededStatus = true;
    public abstract bool RunStateConditionCheck(StateMachine stateMachine);
}
