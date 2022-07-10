using UnityEngine;

namespace SettlementObjects.Units.StatePattern.States
{
    public class MovementState : State
    {
        public MovementState(Unit unit, StateMachine stateMachine) : base(unit, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            // Отключаем остановку
            Unit.Agent.isStopped = false;
            // Включение анимации
            Unit.Animator.SetFloat("Speed", 1); // TODO Нужно исправить "Speed" на константу
        }
        
        // todo дублирование кода с WalkingState и IdleState
        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (Unit.Action.clickedObject.IsClick)
            {
                Unit.Agent.SetDestination(Unit.Action.position);
            }
            

            // TODO Добавить настройки distance и remainingDistacne
            if (Unit.Agent.remainingDistance <= 0.5f) // || Unit.Agent.remainingDistance <= 0.2f && Unit.Agent.hasPath
            {
                Unit.ResetParametersAction();
                StateMachine.ChangeState(Unit.Idle); // TODO перенести состояние из Unit
            }
        }
    }
}