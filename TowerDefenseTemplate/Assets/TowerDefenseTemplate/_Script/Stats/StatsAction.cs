using System;
using UnityEngine;

public abstract class StatsAction : ScriptableObject
{
    public float maxValue;

    public Action<StatsAction> OnValueChange;
    public Action<StatsAction> OnDeprecate;
}
