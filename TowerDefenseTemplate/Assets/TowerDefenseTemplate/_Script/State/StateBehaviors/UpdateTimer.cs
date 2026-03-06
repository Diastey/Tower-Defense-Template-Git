using UnityEngine;

[CreateAssetMenu(fileName = "UpdateTimer", menuName = "States/NewBehaviour/UpdateTimer")]
public class UpdateTimer : StateBehaviour
{
    public TimerIdentifier timer;
    public override void RunStateBehaviour(StateMachine stateMachine)
    {
        stateMachine.stateManager.runtimeTimers[timer.id] -= Time.deltaTime;
    }
}
