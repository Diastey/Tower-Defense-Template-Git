using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateManagers : MonoBehaviour, IStateManager
{
    protected StateMachine stateMachine;

    public State initialState;
    public List<State> states;
    public StatsManager statsManager;
    public SerializableDictionary<int, float> runtimeTimers = new SerializableDictionary<int, float>();
    //public List<bool> flags = new List<bool>();

    private void OnEnable()
    {
        InitialStateMachine();
    }

    public void InitialStateMachine()
    {
        stateMachine = new StateMachine(this);
        for (int i = 0; i < states.Count; i++)
        {
            stateMachine.AddState(states[i].GetDataIdentifierID(), states[i]);
        }
        stateMachine.InitializeState(initialState.GetDataIdentifierID());
    }

    public StatsInstance GetStatsByID(int identifierID)
    {
        return statsManager.GetStatByIdentifierID(identifierID);
    }

    private void Update()
    {
        InputCheck();
        stateMachine.StateMachineUpdate();
    }

    public virtual void InputCheck() { }
}
