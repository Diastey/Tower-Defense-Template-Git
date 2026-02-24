using UnityEngine;

[CreateAssetMenu(fileName = "GunRecharingState", menuName = "Scriptable Objects/States/Gun/GunRecharingState")]
public class GunRecharingState : GunStates
{
    public override void OnEnter()
    {
    }
    public override void OnExit()
    {
    }
    public override void FramesUpdate()
    {
        energy.Modify(Time.deltaTime * ((Energy)energy.statsDef).rechargeRate);

        if (Mathf.Approximately(energy.currentValue, energy.maxValue))
        {
            if (gunManager.canFire)
                stateMachine.ChangeState(gunManager.firingState);
            else
                stateMachine.ChangeState(gunManager.idleState);
        }
    }
    public override void PhysicsUpdate()
    {
    }
}
