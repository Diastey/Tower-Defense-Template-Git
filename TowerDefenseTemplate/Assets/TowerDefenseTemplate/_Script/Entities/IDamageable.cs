using UnityEngine;

public interface IDamageable
{
    public void TakeDamage(DamageInfo damageInfo);
}

public struct DamageInfo
{
    public float damage;
    public Material overrideMaterial;

    public DamageInfo(float damage, Material overrideMaterial)
    {
        this.damage = damage;
        this.overrideMaterial = overrideMaterial;
    }
}