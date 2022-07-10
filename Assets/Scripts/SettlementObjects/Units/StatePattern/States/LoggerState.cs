namespace SettlementObjects.Units.StatePattern.States
{
    public class LoggerState: State
    {
        public LoggerState(Unit unit, StateMachine stateMachine) : base(unit, stateMachine)
        {
        }
        
        public override void Enter()
        {
            base.Enter();
            Unit.ToolAxe.SetActive(true);
            Unit.Animator.SetBool("AxeBlow", true);
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
            Unit.ToolAxe.SetActive(false);
            Unit.Animator.SetBool("AxeBlow", false);
        }
    }
}