using UnityEngine;

public class Gun
{
    public GunStats stats;

    public Gun(GunStats stats)
    {
        this.stats = stats;
    }

    public void FireBullet(Transform firePoint)
    {
        GameObject.Instantiate(stats.bullet, firePoint.position, firePoint.rotation);
    }
}
