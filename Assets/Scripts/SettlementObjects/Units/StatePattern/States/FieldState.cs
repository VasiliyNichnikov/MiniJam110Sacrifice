namespace SettlementObjects.Units.StatePattern.States
{
    public class FieldState: State
    {
        public FieldState(Unit unit, StateMachine stateMachine) : base(unit, stateMachine)
        {
        }
        
        public override void Enter()
        {
            base.Enter();
            Unit.Animator.SetBool("Rise", true);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (Unit.Action.clickedObject.IsClick)
            {
                StateMachine.ChangeState(Unit.Movement);
            }
        }

        public override void Exit()
        {
            base.Exit();
            Unit.Animator.SetBool("Rise", false);
        }
    }
}