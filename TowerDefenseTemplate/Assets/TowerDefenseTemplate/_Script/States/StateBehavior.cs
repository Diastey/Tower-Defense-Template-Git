using System.Collections.Generic;
using UnityEngine;

public abstract class StateBehavior : ScriptableObject, IState
{
    public StateEnum stateID;
    //public StateMachine stateMachine;
    public List<StatsEnum> refStats;

    //public StateBehavior Init(StateMachine stateMachine)
    //{
    //    this.stateMachine = stateMachine;

    //    return this;
    //}

    public virtual void OnEnter(StateManagers stateManager, StateMachine stateMachine) { }
    public virtual void OnExit(StateManagers stateManager, StateMachine stateMachine) { }
    public virtual void FramesUpdate(StateManagers stateManager, StateMachine stateMachine) { }
    public virtual void PhysicsUpdate(StateManagers stateManager, StateMachine stateMachine) { }

    public virtual void OnCheck(StateManagers stateManager, StateMachine stateMachine) { }
}
