using System;
using SettlementObjects.Builders;

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
            if (Unit.Agent.remainingDistance <= 0.5f && Unit.Agent.hasPath) // || Unit.Agent.remainingDistance <= 0.2f && Unit.Agent.hasPath
            {
                // todo не лучшее решение
                if (Unit.Action.clickedObject.IsWork)
                {
                    State state = Unit.Action.clickedObject switch
                    {
                        Trees _ => Unit.Logger,
                        Field _ => Unit.Field,
                        Altar _ => Unit.Dead,
                        _ => throw new ArgumentNullException()
                    };
                    StateMachine.ChangeState(state);
                    Unit.ResetParametersAction();
                    return;
                }
                Unit.ResetParametersAction();
                StateMachine.ChangeState(Unit.Idle);
            }
        }
    }
}