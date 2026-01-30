using System;
using UnityEngine;

[Serializable]
public class StatsInstance
{
    public StatsDefinition statsDef;

    public float currentValue;
    public float maxValue;

    public event Action OnValueChange;
    public event Action OnDeprecate;

    //public event Action<StatsDefinition> OnValueChange;
    //public event Action<StatsDefinition> OnDeprecate;

    public StatsInstance(StatsDefinition statsDef)
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
}
