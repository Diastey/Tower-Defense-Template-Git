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
    public float energyRechargePeriod = 2f;

    [Space]
    public Gun currentGun;
    private Dictionary<string, Gun> equippedGuns = new Dictionary<string, Gun>();

    [Space]
    public bool rechargingEnergy;
    private bool energyDeprecated;
    private bool canFire;
    private float fireCooldownTimer;
    public float energyRechargeTimer;
    private StatsInstance energy;
    public delegate void OnToggleFire(bool toggle);
    public static OnToggleFire onToggleFire;

    //public static event Action<bool> OnToggleFire;

    private void OnEnable()
    {
        onToggleFire += ToggleFire;
    }

    private void OnDisable()
    {
        onToggleFire -= ToggleFire;
    }

    private void Awake()
    {
        detector = GetComponent<Detector>();

        foreach (EquipGun guns in initGuns)
        {
            equippedGuns[guns.buttonName] = new Gun(guns.gunStats);
            //equippedGuns.Add(new Gun(guns.gunStats));
        }

        currentGun = equippedGuns[initGuns[0].buttonName];
        ResetFire();
    }

    private void Start()
    {
        energy = statsManager.GetStat<Energy>();
        energy.OnDeprecate += EnergyDeprecated;
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

        fireCooldownTimer -= Time.deltaTime;
        energyRechargeTimer -= Time.deltaTime;
        rechargingEnergy = (energyRechargeTimer <= 0.0f);

        if (energyDeprecated)
        {
            rechargingEnergy = true;
            canFire = false;
        }

        if (rechargingEnergy)
        {
            energy.Modify(Time.deltaTime * ((Energy)energy.statsDef).rechargeRate);

            if (energyDeprecated && Mathf.Approximately(energy.currentValue, energy.maxValue))
            {
                energyDeprecated = false;
            }
        }

        if (canFire)
        {
            if (fireCooldownTimer <= 0.0f)
                InitiateFire();
        }
    }

    private void InitiateFire()
    {
        energyRechargeTimer = energyRechargePeriod;
        currentGun.FireBullet(firePoint);
        energy.Modify(-currentGun.stats.defaultValue);
        ResetFire();
    }

    private void ResetFire()
    {
        fireCooldownTimer = currentGun.stats.fireFrequency;
    }

    public void EnergyDeprecated()
    {
        energyDeprecated = true;
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
}

[Serializable]
public class EquipGun
{
    public string buttonName;
    public GunStats gunStats;
}
