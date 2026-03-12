using System;
using UnityEngine;

[RequireComponent(typeof(Detector))]
public class WeaponStateManager : StateManagers
{
    public Detector detector;
    public State deprecatedState;
    //public List<EquipGun> initGuns = new List<EquipGun>();

    //[Space]
    //public WeaponStat currentGun;
    //private Dictionary<string, WeaponStat> equippedGuns = new Dictionary<string, WeaponStat>();

    [Space]
    private StatsInstance energy;
    public delegate void OnToggleFire(bool toggle);
    public OnToggleFire onToggleFire;
    public delegate void OnFire();
    public OnFire onFire;

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
}

[Serializable]
public class EquipGun
{
    public string buttonName;
    public WeaponStat gunStats;
}
