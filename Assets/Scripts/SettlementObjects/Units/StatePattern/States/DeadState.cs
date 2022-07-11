using UnityEngine;

namespace SettlementObjects.Units.StatePattern.States
{
    public class DeadState: State
    {
        public DeadState(Unit unit, StateMachine stateMachine) : base(unit, stateMachine)
        {
        }

        public override void Enter()
        {
            Unit.Animator.SetBool("Dead", true);
            Unit.Die();
            base.Enter();
        }
    }
}