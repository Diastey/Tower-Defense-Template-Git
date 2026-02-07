public abstract class States<TContext> : IState
{
    protected readonly TContext context;
    protected readonly StateMachine stateMachine;

    protected States(TContext context, StateMachine stateMachine)
    {
        this.context = context;
        this.stateMachine = stateMachine;
    }

    public virtual void FramesUpdate() { }

    public virtual void OnEnter() { }

    public virtual void OnExit() { }

    public virtual void PhysicsUpdate() { }
}
