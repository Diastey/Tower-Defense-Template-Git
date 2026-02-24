using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Detector))]
public class GunManager : MonoBehaviour
{
    public Detector detector;
    public StatsManager statsManager;
    public Transform firePoint;
    public List<EquipGun> initGuns = new List<EquipGun>();
    //public float energyRechargePeriod = 2f;

    [Space]
    public Gun currentGun;
    private Dictionary<string, Gun> equippedGuns = new Dictionary<string, Gun>();

    [Space]
    public bool canFire;
    public StatsInstance energy;
    public delegate void OnToggleFire(bool toggle);
    public OnToggleFire onToggleFire;
    public delegate void OnFire();
    public OnFire onFire;

    [Space]
    public GunIdleState idleState;
    public GunFiringState firingState;
    public GunRecharingState recharingState;
    private StateMachine stateMachine = new StateMachine();

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
    }

    private void Start()
    {
        energy = statsManager.GetStat<Energy>();
        energy.OnDeprecate += EnergyDeprecated;

        idleState = ScriptableObject.CreateInstance<GunIdleState>();
        firingState = ScriptableObject.CreateInstance<GunFiringState>();
        recharingState = ScriptableObject.CreateInstance<GunRecharingState>();

        idleState.Init(stateMachine, this);
        firingState.Init(stateMachine, this);
        recharingState.Init(stateMachine, this);
        stateMachine.InitializeState(idleState);
    }

    private void OnDestroy()
    {
        energy.OnDeprecate -= EnergyDeprecated;
    }
    public void ToggleFire(bool on)
    {
        canFire = on;
        //if (!canFire)
        //{
        //    ResetFire();
        //}
    }

    private void Update()
    {
        SwitchGunCheck();

        stateMachine.currentState.FramesUpdate();
    }

    public void EnergyDeprecated()
    {
        stateMachine.ChangeState(recharingState);
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
