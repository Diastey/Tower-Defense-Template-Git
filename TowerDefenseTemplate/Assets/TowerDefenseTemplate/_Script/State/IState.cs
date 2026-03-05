public interface IState
{
    void OnEnter(StateMachine stateMachine);
    void OnExit(StateMachine stateMachine);
    void FramesUpdate(StateMachine stateMachine);
    //void PhysicsUpdate(StateManagers stateManager, StateMachine stateMachine);
    void OnCheck(StateMachine stateMachine);
}
