using System.Collections.Generic;
using UnityEngine;

public abstract class StateManagers : MonoBehaviour, IStateManager
{
    protected StateMachine stateMachine;

    public List<StateBehavior> states;
    public StatsManager statsManager;
    public List<bool> flags = new List<bool>();

    private void OnEnable()
    {
        InitialStateMachine();
    }

    public void InitialStateMachine()
    {
        stateMachine = new StateMachine(this);
        for (int i = 0; i < states.Count; i++)
        {
            stateMachine.AddState(states[i].stateID, states[i]);
        }
        stateMachine.InitializeState(StateEnum.IDLE, this, stateMachine);
    }

    public StatsInstance GetStatsByID(int identifierID)
    {
        return statsManager.GetStatByID(identifierID);
    }
}
