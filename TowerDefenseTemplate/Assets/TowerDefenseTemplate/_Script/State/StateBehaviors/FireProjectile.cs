using UnityEngine;

[CreateAssetMenu(fileName = "FireProjectile", menuName = "States/NewBehaviour/FireProjectile")]
public class FireProjectile : StateBehaviour
{
    public GameObjectDefinition projectile;
    public OffsetPositionDefinition offsetPosition;
    public override void RunStateBehaviour(StateMachine stateMachine)
    {
        GameObject.Instantiate(projectile, stateMachine.stateManager.transform.position + offsetPosition.offsetPosition, stateMachine.stateManager.transform.rotation);
    }
}
