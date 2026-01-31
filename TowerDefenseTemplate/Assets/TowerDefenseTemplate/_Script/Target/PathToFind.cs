using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PathToFind", menuName = "Scriptable Objects/PathToFind")]
public class PathToFind : ScriptableObject
{

    public List<Vector3> pathPoints = new List<Vector3>();
}
