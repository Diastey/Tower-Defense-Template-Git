using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public IState currentState;
    public StateManagers stateManager;
    public Dictionary<int, IState> stateMap = new Dictionary<int, IState>();

    public event Action<IState> OnStateChange;

    public StateMachine(StateManagers stateManager)
    {
        this.stateManager = stateManager;
    }

    public void AddState(int stateID, IState state)
    {
        stateMap.Add(stateID, state);
    }

    //public void InitializeState(IState initState)
    //{
    //    currentState = initState;
    //    currentState?.OnEnter();
    //}

    public void InitializeState(int stateID)
    {
        currentState = stateMap[stateID];
        currentState?.OnEnter(this);
    }

    //public void ChangeState(IState newState)
    //{
    //    //Debug.Log(newState);

    //    if (currentState == newState)
    //        return;

    //    currentState?.OnExit();
    //    currentState = newState;
    //    currentState?.OnEnter();

    //    OnStateChange?.Invoke(currentState);
    //}

    public void ChangeState(int stateID)
    {
        if (!stateMap.ContainsKey(stateID))
            return;

        if (currentState == stateMap[stateID])
            return;
        //Debug.Log(stateID);

        currentState?.OnExit(this);
        currentState = stateMap[stateID];
        currentState?.OnEnter(this);

        OnStateChange?.Invoke(currentState);
    }

    public void StateMachineUpdate()
    {
        currentState?.FramesUpdate(this);
    }
}
