using System;
using UnityEngine;

[Serializable]
public class StatsInstance
{
    public StatDefinition statsDef;

    public float currentValue;
    public float maxValue;

    public event Action OnValueChange;
    public event Action OnDeprecate;

    public StatsInstance(StatDefinition statsDef)
    {
        this.statsDef = statsDef;
        maxValue = statsDef.defaultValue;
        currentValue = maxValue;
    }

    public void Modify(float amount)
    {
        float previous = currentValue;
        currentValue = Mathf.Clamp(currentValue + amount, 0, maxValue);

        if (!Mathf.Approximately(previous, currentValue))
            OnValueChange?.Invoke();

        if (currentValue <= 0)
            OnDeprecate?.Invoke();
    }

    //public StatsInstance CheckStatsID(int statsID)
    //{
    //    if (statsID == statsDef.statsID)
    //        return this;
    //    else
    //        return null;
    //}
}
