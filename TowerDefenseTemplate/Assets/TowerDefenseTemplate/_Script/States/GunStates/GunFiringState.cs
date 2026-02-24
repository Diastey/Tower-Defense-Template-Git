using UnityEngine;

[CreateAssetMenu(fileName = "GunFiringState", menuName = "Scriptable Objects/States/Gun/GunFiringState")]
public class GunFiringState : GunStates
{
    public float energyRechargePeriod = 2f;

    private float fireCooldownTimer;
    private float energyRechargeTimer;
    public override void OnEnter()
    {
        ResetFire();
    }
    public override void FramesUpdate()
    {
        fireCooldownTimer -= Time.deltaTime;
        energyRechargeTimer -= Time.deltaTime;

        if (fireCooldownTimer <= 0.0f)
            InitiateFire();

        if (energyRechargeTimer <= 0.0f)
            stateMachine.ChangeState(gunManager.idleState);
    }

    private void InitiateFire()
    {
        ResetFire();
        gunManager.onFire?.Invoke();
        energy.Modify(-gunManager.currentGun.stats.defaultValue);
    }
    private void ResetFire()
    {
        fireCooldownTimer = gunManager.currentGun.stats.fireFrequency;
        energyRechargeTimer = energyRechargePeriod;
    }
}
