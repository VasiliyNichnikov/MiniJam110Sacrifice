using UnityEngine;

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
            if (Unit.Action.clickedObject.IsClick == false) return;
            StateMachine.ChangeState(Unit.Movement);
        }
    }
}