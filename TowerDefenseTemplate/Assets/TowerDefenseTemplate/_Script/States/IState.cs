public interface IState
{
    void OnEnter(StateManagers stateManager, StateMachine stateMachine);
    void OnExit(StateManagers stateManager, StateMachine stateMachine);
    void PhysicsUpdate(StateManagers stateManager, StateMachine stateMachine);
    void FramesUpdate(StateManagers stateManager, StateMachine stateMachine);
    void OnCheck(StateManagers stateManager, StateMachine stateMachine);
}
