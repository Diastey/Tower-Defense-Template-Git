using System;
using UnityEngine;

public class StateMachine : MonoBehaviour
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
        if (currentState == newState)
            return;

        currentState?.OnExit();
        currentState = newState;
        currentState?.OnEnter();

        OnStateChange?.Invoke(currentState);
    }

    private void Update()
    {
        currentState?.FramesUpdate();
    }

    private void FixedUpdate()
    {
        currentState?.PhysicsUpdate();
    }
}
