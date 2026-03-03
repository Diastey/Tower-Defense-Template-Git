using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Scriptable Objects/Stats/Gun")]
public class GunStats : StatDefinition
{
    public GameObject bullet;
    public float fireFrequency;
}
