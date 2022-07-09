using SelectedObjects.Units.StatePattern;
using UnityEngine;

namespace SettlementObjects.Units.StatePattern.States
{
    public class WalkingState : State
    {
        public WalkingState(Unit unit, StateMachine stateMachine) : base(unit, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            // Отключаем остановку
            Unit.Agent.isStopped = false;
            // Включение анимации
            // Unit.Animator.SetFloat("Speed", 1); // TODO Нужно исправить "Speed" на константу
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            var unitPosition = Unit.ThisTransform.position;
            var distance = Vector3.Distance(unitPosition, Unit.Click.position); // TODO Vector3.zero - заглушка
            MonoBehaviour.print($"Unit agent, hasPath: {Unit.Agent.hasPath}; " +
                                $"pathStatus: {Unit.Agent.pathStatus}; " +
                                $"remainingDistance: {Unit.Agent.remainingDistance};");
            // TODO Костыль
            if (Unit.Click.hit.IsGround)
            {
                Unit.Agent.SetDestination(Unit.Click.position);
            }

            // TODO Добавить настройки distance и remainingDistacne
            if (distance <= 0.5f) // || Unit.Agent.remainingDistance <= 0.2f && Unit.Agent.hasPath
            {
                Unit.ResetClick();
                StateMachine.ChangeState(Unit.Idle); // TODO перенести состояние из Unit
            }
        }
    }
}