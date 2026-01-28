using System;
using UnityEngine;

[Serializable]
public class StatsData
{
    public float currentValue;
    public float maxValue;

    public StatsAction statsActions;

    public void Modify(float amount)
    {
        currentValue = Mathf.Clamp(currentValue + amount, 0, maxValue);
        statsActions.OnValueChange?.Invoke(statsActions);

        if (currentValue <= 0)
            statsActions.OnDeprecate?.Invoke(statsActions);
    }
}
