using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float projectileSpeed;
    public float bulletLifeTime = 2f;

    private Material materialToOverride;
    private float lifeTimeTimer = 0.0f;

    private void Awake()
    {
        materialToOverride = GetComponent<MeshRenderer>().material;
    }

    private void Start()
    {
        lifeTimeTimer = bulletLifeTime;
    }

    private void Update()
    {
        transform.position += transform.forward * projectileSpeed * Time.deltaTime;

        lifeTimeTimer -= Time.deltaTime;
        if (lifeTimeTimer <= 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable target))
        {
            HitTarget(target);
        }
    }

    private void HitTarget(IDamageable target)
    {
        DamageInfo damageInfo = new DamageInfo(damage, materialToOverride);
        target.TakeDamage(damageInfo);
        Destroy(gameObject);
    }
}
