using UnityEngine;

public abstract class StateManagers : MonoBehaviour, IStateManager
{
    protected readonly StateMachine stateMachine = new StateMachine();

    public StateBehavior initialState;

    private void OnEnable()
    {
        InitialStateMachine();
    }

    public void InitialStateMachine()
    {
        stateMachine.InitializeState(initialState);
    }
}
