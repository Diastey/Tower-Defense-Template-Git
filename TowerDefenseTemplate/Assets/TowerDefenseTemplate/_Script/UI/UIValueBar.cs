using UnityEngine;
using UnityEngine.UI;

public class UIValueBar : MonoBehaviour
{
    public StatsManager statsManager;
    public StatDefinition refStatIdentifier;

    private StatsInstance refStat;
    private float maxValue;
    private Scrollbar scrollbar;

    private void Awake()
    {
        scrollbar = GetComponent<Scrollbar>();
    }

    private void Start()
    {
        refStat = statsManager.GetStatByID(refStatIdentifier.identifierID);

        maxValue = refStat.maxValue;
        scrollbar.size = refStat.currentValue / maxValue;
        refStat.OnValueChange += ScrollBarUpdate;
    }

    private void OnDestroy()
    {
        refStat.OnValueChange -= ScrollBarUpdate;
    }

    public void ScrollBarUpdate()
    {
        scrollbar.size = refStat.currentValue / maxValue;
    }
}
