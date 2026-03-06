using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateManagers : MonoBehaviour, IStateManager
{
    protected StateMachine stateMachine;

    public State initialState;
    public List<State> states;
    public StatsManager statsManager;
    public List<FlagDefinition> flagsList = new List<FlagDefinition>();
    public List<OffsetPositionDefinition> offsetTransformList = new List<OffsetPositionDefinition>();
    public List<GameObjectDefinition> gameObjectList = new List<GameObjectDefinition>();
    //public List<WeaponStat> weaponStatList;

    public Dictionary<int, OffsetPositionDefinition> offsetTransforms = new Dictionary<int, OffsetPositionDefinition>();
    public Dictionary<int, GameObjectDefinition> gameObjects = new Dictionary<int, GameObjectDefinition>();
    public Dictionary<int, bool> runtimeFlags = new Dictionary<int, bool>();
    public Dictionary<int, float> runtimeTimers = new Dictionary<int, float>();
    //public Dictionary<int, WeaponStat> weapons = new();
    //public List<bool> flags = new List<bool>();

    private void OnEnable()
    {
        InitialStateMachine();
    }

    private void Awake()
    {
        for (int i = 0; i < flagsList.Count; i++)
        {
            runtimeFlags.Add(flagsList[i].GetDataIdentifierID(), flagsList[i].defaultStatus);
        }
        for (int i = 0; i < offsetTransformList.Count; i++)
        {
            offsetTransforms.Add(offsetTransformList[i].GetDataIdentifierID(), offsetTransformList[i]);
        }
        for (int i = 0; i < gameObjectList.Count; i++)
        {
            gameObjects.Add(gameObjectList[i].GetDataIdentifierID(), gameObjectList[i]);
        }
        //for (int i = 0; i < weaponStatList.Count; i++)
        //{
        //    weapons.Add(weaponStatList[i].GetDataIdentifierID(), weaponStatList[i]);
        //}

        AwakeFunctions();
    }

    public virtual void AwakeFunctions() { }

    public void InitialStateMachine()
    {
        stateMachine = new StateMachine(this);
        for (int i = 0; i < states.Count; i++)
        {
            stateMachine.AddState(states[i].GetDataID(), states[i]);
        }
        if (initialState)
            stateMachine.InitializeState(initialState.GetDataID());
    }
    private void Update()
    {
        InputCheck();
        stateMachine.StateMachineUpdate();
    }

    public virtual void InputCheck() { }

    public StatsInstance GetStatsByIdentifierID(int identifierID)
    {
        return statsManager.GetStatByIdentifierID(identifierID);
    }

    public StatsInstance GetStatsByDataID(int dataID)
    {
        return statsManager.GetStatByDataID(dataID);
    }

    public StatsInstance GetStatsByInstanceID(int identifierID, int instanceID)
    {
        return statsManager.GetStatByInstanceID(identifierID, instanceID);
    }
}
