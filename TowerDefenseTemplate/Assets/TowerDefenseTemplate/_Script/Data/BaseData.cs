using UnityEngine;

public class BaseData : ScriptableObject
{
    public IdentifierID identifierID;
    public int instanceID;

    public int GetDataIdentifierID()
    {
        return identifierID.id;
    }

    public int GetDataID()
    {
        return identifierID.id + instanceID;
    }

    public int GetDataInstanceID()
    {
        return instanceID;
    }
}
