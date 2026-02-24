using UnityEngine;

public abstract class States : ScriptableObject, IState
{
    public StateMachine stateMachine;

    public States Init(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;

        return this;
    }

    public virtual void OnEnter() { }
    public virtual void OnExit() { }
    public virtual void FramesUpdate() { }
    public virtual void PhysicsUpdate() { }
}
