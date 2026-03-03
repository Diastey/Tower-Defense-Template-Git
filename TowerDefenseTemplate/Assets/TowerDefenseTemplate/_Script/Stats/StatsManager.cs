using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class StatsManager : MonoBehaviour
{
    public List<StatDefinition> statsList = new List<StatDefinition>();

    public SerializableDictionary<int, StatsInstance> stats = new();

    private void Awake()
    {
        stats.Clear();
        foreach (var def in statsList)
        {
            if (stats.ContainsKey(def.identifierID))
                continue;

            stats[def.identifierID] = new StatsInstance(def);
        }
    }

    public StatsInstance GetStatByID(int identifierID)
    {
        return stats.TryGetValue(identifierID, out var stat) ? stat : null;
    }
}
