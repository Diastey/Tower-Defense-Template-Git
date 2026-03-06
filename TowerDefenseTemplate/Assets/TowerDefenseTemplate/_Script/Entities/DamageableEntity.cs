using UnityEngine;

[RequireComponent(typeof(StatsManager))]
public class DamageableEntity : MonoBehaviour, IDamageable
{
    public StatsManager stats;
    public MeshRenderer meshRenderer;
    private Material originalMaterial;
    public float overrideMaterialPeriod = 0.1f;
    public BaseData healthStat;

    [Space]
    private bool materialChanged;
    private float overrideMaterialTimer = 0.0f;

    private void Awake()
    {
        originalMaterial = meshRenderer.material;

        materialChanged = false;
    }

    private void Start()
    {
        stats.GetStatByIdentifierID(healthStat.GetDataIdentifierID()).OnDeprecate += Death;
    }

    private void Update()
    {
        if (materialChanged)
        {
            overrideMaterialTimer -= Time.deltaTime;

            if (overrideMaterialTimer <= 0.0f)
                ResetColor();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        stats.GetStatByIdentifierID(healthStat.GetDataIdentifierID()).OnDeprecate -= Death;
    }

    public void TakeDamage(DamageInfo damageInfo)
    {
        stats.GetStatByIdentifierID(healthStat.GetDataIdentifierID()).Modify(-damageInfo.damage);
        ChangeColor(damageInfo.overrideMaterial);
    }

    public void ChangeColor(Material overrideMaterial)
    {
        overrideMaterialTimer = overrideMaterialPeriod;
        materialChanged = true;

        meshRenderer.material = overrideMaterial;
    }

    public void ResetColor()
    {
        materialChanged = false;

        meshRenderer.material = originalMaterial;
    }
}
