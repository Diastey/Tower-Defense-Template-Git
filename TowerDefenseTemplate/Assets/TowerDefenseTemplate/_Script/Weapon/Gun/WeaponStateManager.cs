using System;
using System.Collections.Generic;
using UnityEngine;

public enum GM_Flags
{
    CanFire
}

[RequireComponent(typeof(Detector))]
public class WeaponStateManager : StateManagers
{
    public Detector detector;
    //public StatDefinition energyStatsIDRef;
    public Transform firePoint;
    public List<EquipGun> initGuns = new List<EquipGun>();
    public BaseIdentifier weaponEnergyIdentifier;
    //public float energyRechargePeriod = 2f;

    [Space]
    public Gun currentGun;
    private Dictionary<string, Gun> equippedGuns = new Dictionary<string, Gun>();

    [Space]
    public StatsInstance energy;
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
        onFire += FireBullet;
    }

    private void OnDisable()
    {
        onToggleFire -= ToggleFire;
        onFire -= FireBullet;
    }

    private void Awake()
    {
        detector = GetComponent<Detector>();

        foreach (EquipGun guns in initGuns)
        {
            equippedGuns[guns.buttonName] = new Gun(guns.gunStats);
        }

        currentGun = equippedGuns[initGuns[0].buttonName];

        flags.Add(false);
    }

    private void Start()
    {
        energy = statsManager.GetStatByID(weaponEnergyIdentifier.identifierID);
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
        flags[(int)GM_Flags.CanFire] = on;
        //if (!canFire)
        //{
        //    ResetFire();
        //}
    }

    private void Update()
    {
        SwitchGunCheck();
        //Debug.Log(stateMachine.currentState);
        stateMachine.currentState.FramesUpdate(this, stateMachine);
    }

    public void EnergyDeprecated()
    {
        stateMachine.ChangeState(StateEnum.RECHARGING, this, stateMachine);
    }

    public void SwitchGunCheck()
    {
        foreach (KeyValuePair<string, Gun> guns in equippedGuns)
        {
            if (Input.GetKey(guns.Key))
            {
                currentGun = guns.Value;
                Debug.Log("SWICH TO " + guns.Value.stats.name);
            }
        }
    }

    public void FireBullet()
    {
        currentGun.FireBullet(firePoint);
    }
}

[Serializable]
public class EquipGun
{
    public string buttonName;
    public GunStats gunStats;
}
