using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBehaviour", menuName = "States/NewBehaviour")]
public abstract class StateBehaviour : BaseData, IStateBehaviour
{
    public abstract void RunStateBehaviour(StateMachine stateMachine);
}
