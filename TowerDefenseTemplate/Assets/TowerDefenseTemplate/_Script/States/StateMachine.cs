using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public IState currentState;
    public StateManagers stateManager;
    public Dictionary<StateEnum, IState> stateMap = new Dictionary<StateEnum, IState>();

    public event Action<IState> OnStateChange;

    public StateMachine(StateManagers stateManager)
    {
        this.stateManager = stateManager;
    }

    public void AddState(StateEnum stateID, IState state)
    {
        stateMap.Add(stateID, state);
    }

    //public void InitializeState(IState initState)
    //{
    //    currentState = initState;
    //    currentState?.OnEnter();
    //}

    public void InitializeState(StateEnum stateID, StateManagers stateManager, StateMachine stateMachine)
    {
        currentState = stateMap[stateID];
        currentState?.OnEnter(stateManager,stateMachine);
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

    public void ChangeState(StateEnum stateID, StateManagers stateManager, StateMachine stateMachine)
    {
        //Debug.Log(newState);

        if (currentState == stateMap[stateID])
            return;

        currentState?.OnExit(stateManager, stateMachine);
        currentState = stateMap[stateID];
        currentState?.OnEnter(stateManager, stateMachine);

        OnStateChange?.Invoke(currentState);
    }
}
