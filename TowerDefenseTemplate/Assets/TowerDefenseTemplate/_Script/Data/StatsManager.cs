using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class StatsManager : MonoBehaviour
{
    public List<StatDefinition> statsList = new List<StatDefinition>();

    //public SerializableDictionary<int, StatsInstance> stats = new();
    public Dictionary<int, Dictionary<int, StatsInstance>> stats = new();

    private void Awake()
    {
        stats.Clear();
        foreach (var def in statsList)
        {

            if (!stats.ContainsKey(def.GetDataIdentifierID()))
                stats.Add(def.GetInstanceID(), new Dictionary<int, StatsInstance>());

            stats[def.GetDataIdentifierID()].Add(def.GetDataInstanceID(), new StatsInstance(def));

            //if (stats.ContainsKey(def.GetDataIdentifierID()))
            //    continue;

            //stats[def.GetDataIdentifierID()] = new StatsInstance(def);
        }
    }

    public StatsInstance GetStatByIdentifierID(int identifierID)
    {
        return stats.TryGetValue(identifierID, out Dictionary<int, StatsInstance> stat) ? stat.FirstOrDefault().Value : null;
    }
    public StatsInstance GetStatByInstanceID(int identifierID, int instanceID)
    {
        return stats.TryGetValue(identifierID, out Dictionary<int, StatsInstance> statIdentifier) ?
            statIdentifier.TryGetValue(instanceID, out var stat) ? stat : null
            : null;
    }
    public StatsInstance GetStatByDataID(int dataID)
    {
        int instanceID = dataID % IDTable.INSTANCE_MODULUS;
        int identifierID = dataID - instanceID;
        return stats.TryGetValue(identifierID, out Dictionary<int, StatsInstance> statIdentifier) ?
            statIdentifier.TryGetValue(instanceID, out var stat) ? stat : null
            : null;
    }
}
