public abstract class GunStates : States
{
    protected GunManager gunManager;
    protected StatsInstance energy;

    public States Init(StateMachine stateMachine, GunManager gunManager)
    {
        this.stateMachine = stateMachine;
        this.gunManager = gunManager;
        energy = gunManager.energy;

        return this;
    }
}
