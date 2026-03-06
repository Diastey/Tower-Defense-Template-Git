using UnityEngine;

[CreateAssetMenu(fileName = "FireProjectile", menuName = "States/NewBehaviour/FireProjectile")]
public class FireProjectile : StateBehaviour
{
    public GameObjectDefinition projectile;
    public OffsetPositionDefinition offsetPosition;
    public override void RunStateBehaviour(StateMachine stateMachine)
    {
        Instantiate(
            projectile.defaultPrefab,
            stateMachine.stateManager.transform.TransformPoint(offsetPosition.offsetPosition),
            stateMachine.stateManager.transform.rotation
        );
    }
}
