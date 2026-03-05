//using UnityEngine;

////[CreateAssetMenu(fileName = "FireProjectileState", menuName = "Scriptable Objects/State/FireProjectileState")]
//public class FireProjectileState : StateBehaviour
//{
//    ////public float energyRechargePeriod = 2f;

//    ////private float fireCooldownTimer;
//    ////private float energyRechargeTimer;
//    ////public override void OnEnter(StateManagers stateManager, StateMachine stateMachine)
//    ////{
//    ////    if (stateManager.GetType() != typeof(WeaponStateManager))
//    ////        return;

//    ////    WeaponStateManager gunManager = (WeaponStateManager)stateManager;
//    ////    gunManager.onFire?.Invoke();
//    ////    gunManager.energy.Modify(-gunManager.currentGun.stats.defaultValue);
//    ////    stateMachine.ChangeState(StateEnum.TARGETLOCKED, gunManager, stateMachine);
//    ////}
//    //public override void OnEnter(StateManagers stateManager, StateMachine stateMachine)
//    //{
//    //    //if (stateManager.GetType() != typeof(WeaponStateManager))
//    //    //    return;

//    //    //WeaponStateManager gunManager = (WeaponStateManager)stateManager;
//    //    //ResetFire(gunManager);
//    //}
//    //public override void FramesUpdate(StateManagers stateManager, StateMachine stateMachine)
//    //{
//    //    //if (stateManager.GetType() != typeof(WeaponStateManager))
//    //    //    return;

//    //    //WeaponStateManager gunManager = (WeaponStateManager)stateManager;
//    //    //fireCooldownTimer -= Time.deltaTime;
//    //    //energyRechargeTimer -= Time.deltaTime;

//    //    //if (fireCooldownTimer <= 0.0f && stateManager.flags[(int)GM_Flags.CanFire])
//    //    //    InitiateFire(gunManager);

//    //    //if (energyRechargeTimer <= 0.0f)
//    //    //    stateMachine.ChangeState(StateEnum.IDLE, stateManager, stateMachine);
//    //}

//    ////private void ResetFire(WeaponStateManager gunManager)
//    ////{
//    ////    fireCooldownTimer = gunManager.currentGun.stats.fireFrequency;
//    ////    energyRechargeTimer = energyRechargePeriod;
//    ////}
//    ////private void InitiateFire(WeaponStateManager gunManager)
//    ////{
//    ////    ResetFire(gunManager);
//    ////    gunManager.onFire?.Invoke();
//    ////    gunManager.energy.Modify(-gunManager.currentGun.stats.defaultValue);
//    ////}
//}
