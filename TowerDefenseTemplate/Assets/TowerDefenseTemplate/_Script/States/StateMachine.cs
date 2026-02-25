using System;
using UnityEngine;

public class StateMachine
{
    public IState currentState;
    public event Action<IState> OnStateChange;

    public void InitializeState(IState initState)
    {
        currentState = initState;
        currentState?.OnEnter();
    }

    public void ChangeState(IState newState)
    {
        //Debug.Log(newState);

        if (currentState == newState)
            return;

        currentState?.OnExit();
        currentState = newState;
        currentState?.OnEnter();

        OnStateChange?.Invoke(currentState);
    }
}
