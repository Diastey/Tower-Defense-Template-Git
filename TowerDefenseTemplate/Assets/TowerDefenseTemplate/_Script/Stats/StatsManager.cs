using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public List<StatsData> statsList = new List<StatsData>();

    public T GetStat<T>() where T : StatsData
    {
        for (int i = 0; i < statsList.Count; i++)
        {
            if (statsList[i] is T stat)
                return stat;
        }
        return null;
    }
}
