public abstract class GunStates : StateBehavior
{
    protected GunManager gunManager;
    protected StatsInstance energy;

    public StateBehavior Init(StateMachine stateMachine, GunManager gunManager)
    {
        this.stateMachine = stateMachine;
        this.gunManager = gunManager;
        energy = gunManager.energy;

        return this;
    }
}
