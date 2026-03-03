using UnityEngine;

[CreateAssetMenu(fileName = "NewGameObject", menuName = "Identifier/NewGameObject")]
public class GameObjectDefinition : ScriptableObject
{
    public GameObject defaultPrefab;
}
