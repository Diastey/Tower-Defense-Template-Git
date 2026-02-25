using UnityEngine;

public abstract class StateBehavior : ScriptableObject, IState
{
    public int stateID;
    public StateMachine stateMachine;

    public StateBehavior Init(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;

        return this;
    }

    public virtual void OnEnter() { }
    public virtual void OnExit() { }
    public virtual void FramesUpdate() { }
    public virtual void PhysicsUpdate() { }
}
