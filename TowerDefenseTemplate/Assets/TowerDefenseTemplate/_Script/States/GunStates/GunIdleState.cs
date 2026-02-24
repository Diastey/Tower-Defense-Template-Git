using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

[CreateAssetMenu(fileName = "GunIdleState", menuName = "Scriptable Objects/States/Gun/GunIdleState")]
public class GunIdleState : GunStates
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
        if (gunManager.canFire)
            stateMachine.ChangeState(gunManager.firingState);
    }
    public override void PhysicsUpdate()
    {
    }
}
