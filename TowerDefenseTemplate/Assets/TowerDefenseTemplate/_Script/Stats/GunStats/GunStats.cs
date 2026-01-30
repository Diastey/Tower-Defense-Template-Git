using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Scriptable Objects/Stats/Gun")]
public class GunStats : StatsDefinition
{
    public GameObject bullet;
    public float fireFrequency;
}
