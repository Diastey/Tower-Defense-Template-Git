using UnityEngine;

[CreateAssetMenu(fileName = "TimerCheck", menuName = "States/CheckCondition/TimerCheck")]
public class TimerCheck : CheckCondition
{
    public TimerIdentifier timer;
    public override bool RunStateConditionCheck(StateMachine stateMachine)
    {
        return (stateMachine.stateManager.runtimeTimers[timer.id] <= 0.0f) == neededStatus;
    }
}
