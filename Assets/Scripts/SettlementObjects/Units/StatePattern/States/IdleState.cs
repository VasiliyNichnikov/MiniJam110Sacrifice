using SettlementObjects.Builders;

namespace SettlementObjects.Units.StatePattern.States
{
    public class IdleState : State
    {
        public IdleState(Unit unit, StateMachine stateMachine) : base(unit, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            // Отключаем анимацию
            // Unit.Animator.SetFloat("Speed", 0); // TODO Нужно исправить "Speed" на константу
            // Прекращение движения
            Unit.Agent.isStopped = true;
            // Прекращаем действия, которые могут выполняться юнитом
        }
        
        // TODO Дублирование кода с WalkState
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (Unit.Click.hit.IsClick == false) return;
            if (Unit.Click.hit.IsAction)
            {
                var builder = GetBuilderForWork();
                if (builder is Trees)
                {
                    StateMachine.ChangeState(Unit.Felling);
                    return;
                }
            }
            StateMachine.ChangeState(Unit.Walking); // TODO перенести состояние из Unit
        }
    }
}