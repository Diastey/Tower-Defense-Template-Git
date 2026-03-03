using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

//[CreateAssetMenu(fileName = "CooldownState", menuName = "Scriptable Objects/States/CooldownState")]
public class CooldownState : StateBehavior
{
    public override void FramesUpdate(StateManagers stateManager, StateMachine stateMachine)
    {
        //stateManager.GetStatsByID(refStats[0]).Modify(Time.deltaTime * ((Energy)stateManager.GetStatsByID(refStats[0]).statsDef).rechargeRate);
        //if (stateManager.flags[(int)GM_Flags.CanFire])
        //    stateMachine.ChangeState(StateEnum.ATTACK, stateManager, stateMachine);
    }
}
