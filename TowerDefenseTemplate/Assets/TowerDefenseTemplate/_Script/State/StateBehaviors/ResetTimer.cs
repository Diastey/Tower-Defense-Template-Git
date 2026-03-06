using UnityEngine;

[CreateAssetMenu(fileName = "ResetTimer", menuName = "States/NewBehaviour/ResetTimer")]
public class ResetTimer : StateBehaviour
{
    public TimerIdentifier timer;
    public StatDefinition timerTimePeriod;
    public override void RunStateBehaviour(StateMachine stateMachine)
    {
        if (!stateMachine.stateManager.runtimeTimers.ContainsKey(timer.id))
        {
            stateMachine.stateManager.runtimeTimers.Add(timer.id, timerTimePeriod.defaultValue);
        }
        else
        {
            stateMachine.stateManager.runtimeTimers[timer.id] = timerTimePeriod.defaultValue;
        }
    }
}
