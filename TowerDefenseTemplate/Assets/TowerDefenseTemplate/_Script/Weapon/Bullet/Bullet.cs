using UnityEngine;

public class Bullet : MonoBehaviour
{
    public StatDefinition damage;
    public StatDefinition projectileSpeed;
    public StatDefinition bulletLifeTime;

    private Material materialToOverride;
    private float lifeTimeTimer = 0.0f;

    private void Awake()
    {
        materialToOverride = GetComponent<MeshRenderer>().material;
    }

    private void Start()
    {
        lifeTimeTimer = bulletLifeTime.defaultValue;
    }

    private void Update()
    {
        transform.position += transform.forward * projectileSpeed.defaultValue * Time.deltaTime;

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
        DamageInfo damageInfo = new DamageInfo(damage.defaultValue, materialToOverride);
        target.TakeDamage(damageInfo);
        Destroy(gameObject);
    }
}
