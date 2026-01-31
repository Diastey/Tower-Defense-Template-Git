using UnityEngine;

[RequireComponent(typeof(StatsManager))]
public class StateManager : MonoBehaviour, IDamageable
{
    public StatsManager stats;
    public MeshRenderer meshRenderer;
    private Material originalMaterial;
    public float overrideMaterialPeriod = 0.1f;

    [Space]
    private bool materialChanged;
    private float overrideMaterialTimer = 0.0f;

    private void Awake()
    {
        stats = GetComponent<StatsManager>();
        if (TryGetComponent<MeshRenderer>(out MeshRenderer _meshRenderer))
            meshRenderer = _meshRenderer;
        originalMaterial = meshRenderer.material;

        materialChanged = false;
    }

    private void Start()
    {
        stats.GetStat<Health>().OnDeprecate += Death;
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
        stats.GetStat<Health>().OnDeprecate -= Death;
    }

    public void TakeDamage(DamageInfo damageInfo)
    {
        stats.GetStat<Health>().Modify(-damageInfo.damage);
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
