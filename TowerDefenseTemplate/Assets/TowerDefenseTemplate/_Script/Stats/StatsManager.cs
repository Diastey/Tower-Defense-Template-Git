using System;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public List<StatsDefinition> statsList = new List<StatsDefinition>();

    private readonly Dictionary<Type, StatsInstance> stats = new();

    private void Awake()
    {
        foreach (var def in statsList)
        {
            var type = def.GetType();

            if (stats.ContainsKey(type))
                continue;

            stats[type] = new StatsInstance(def);
        }
    }

    public StatsInstance GetStat<T>() where T : StatsDefinition
    {
        return stats.TryGetValue(typeof(T), out var stat) ? stat : null;
    }
}
