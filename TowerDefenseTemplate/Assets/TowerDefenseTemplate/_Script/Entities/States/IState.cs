public interface IState
{
    void OnEnter();
    void OnExit();
    void PhysicsUpdate();
    void FramesUpdate();
}
