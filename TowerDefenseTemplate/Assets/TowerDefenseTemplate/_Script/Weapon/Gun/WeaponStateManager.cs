using System;
using System.Collections.Generic;
using UnityEngine;

//public enum GM_Flags
//{
//    CanFire
//}

[RequireComponent(typeof(Detector))]
public class WeaponStateManager : StateManagers
{
    public Detector detector;
    public State deprecatedState;
    //public StatDefinition energyStatsIDRef;
    //public Transform firePoint;
    //public List<EquipGun> initGuns = new List<EquipGun>();
    //public BaseData weaponEnergyIdentifier;
    //public float energyRechargePeriod = 2f;

    //[Space]
    //public WeaponStat currentGun;
    //private Dictionary<string, WeaponStat> equippedGuns = new Dictionary<string, WeaponStat>();

    [Space]
    private StatsInstance energy;
    public delegate void OnToggleFire(bool toggle);
    public OnToggleFire onToggleFire;
    public delegate void OnFire();
    public OnFire onFire;

    //[Space]
    //public CooldownState idleState;
    //public FireProjectileState firingState;
    //public RecharingState recharingState;
    //private StateMachine stateMachine = new StateMachine();

    private void OnEnable()
    {
        onToggleFire += ToggleFire;
        //onFire += FireBullet;
    }

    private void OnDisable()
    {
        onToggleFire -= ToggleFire;
        //onFire -= FireBullet;
    }
    public override void AwakeFunctions()
    {
        detector = GetComponent<Detector>();

        //foreach (EquipGun guns in initGuns)
        //{
        //    equippedGuns[guns.buttonName] = guns.gunStats;
        //}

        //currentGun = equippedGuns[initGuns[0].buttonName];
    }

    private void Start()
    {
        energy = statsManager.GetStatByIdentifierID(IDTable.ENERGY);
        energy.OnDeprecate += EnergyDeprecated;
        InitialStateMachine();
        //idleState = ScriptableObject.CreateInstance<CooldownState>();
        //firingState = ScriptableObject.CreateInstance<FireProjectileState>();
        //recharingState = ScriptableObject.CreateInstance<RecharingState>();

        //idleState.Init(stateMachine, this);
        //firingState.Init(stateMachine, this);
        //recharingState.Init(stateMachine, this);
        //stateMachine.InitializeState(idleState);
    }

    private void OnDestroy()
    {
        energy.OnDeprecate -= EnergyDeprecated;
    }
    public void ToggleFire(bool on)
    {
        runtimeFlags[IDTable.CAN_FIRE] = on;
        //if (!canFire)
        //{
        //    ResetFire();
        //}
    }

    public void EnergyDeprecated()
    {
        stateMachine.ChangeState(deprecatedState.GetDataID());
    }

    public override void InputCheck()
    {
        //foreach (KeyValuePair<string, WeaponStat> guns in equippedGuns)
        //{
        //    if (Input.GetKey(guns.Key))
        //    {
        //        currentGun = guns.Value;
        //        //Debug.Log("SWICH TO " + guns.Value.stats.name);
        //    }
        //}
    }

    //public void FireBullet()
    //{
    //    currentGun.FireBullet(firePoint);
    //}
}

[Serializable]
public class EquipGun
{
    public string buttonName;
    public WeaponStat gunStats;
}
