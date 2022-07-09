using SettlementObjects.Builders;
using UnityEngine;

namespace SettlementObjects.Units.StatePattern.States
{
    public class FellingTreesState: State
    {

        private IBuilder _work;
        
        public FellingTreesState(Unit unit, StateMachine stateMachine) : base(unit, stateMachine)
        {
        }
        
        public override void Enter()
        {
            base.Enter();
            // Отключаем остановку
            Unit.Agent.isStopped = false;
            // Включение анимации
            // Unit.Animator.SetFloat("Speed", 1); // TODO Нужно исправить "Speed" на константу
            
            // MonoBehaviour.print("Enter Felling");
            if (Unit.Click.hit.IsAction)
            {
                _work = GetBuilderForWork();
                if (_work.IsJobAvailable())
                {
                    // MonoBehaviour.print("GetJob");
                    var hitNow = Unit.Click.hit;
                    var position = _work.SubscribeToJob();
                    Unit.SetClick((hitNow, position));

                } // todo иначе нужно сообщить, что мест для работы нет
            }
        }
        
        // todo дублирование кода с WalkingState
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            var unitPosition = Unit.ThisTransform.position;
            var distance = Vector3.Distance(unitPosition, Unit.Click.position); // TODO Vector3.zero - заглушка
            // MonoBehaviour.print($"Unit agent, hasPath: {Unit.Agent.hasPath}; " +
            //                     $"pathStatus: {Unit.Agent.pathStatus}; " +
            //                     $"remainingDistance: {Unit.Agent.remainingDistance};");

            if (Unit.Click.hit.IsClick)
            {
                if (Unit.Click.hit.IsAction == false)
                {
                    StateMachine.ChangeState(Unit.Walking);
                    return;
                }
                
                // todo нужно переходить к точке, которая инициализируется в методе Enter
                Unit.Agent.SetDestination(Unit.Click.position);
            }
            
            // TODO дублирование
            // TODO Добавить настройки distance и remainingDistacne
            if (distance <= 0.5f)
            {
                Unit.Agent.isStopped = true;
            }
        }

        public override void Exit()
        {
            base.Exit();
            _work.UnsubscribeToWork();   
            MonoBehaviour.print("Exit Felling");
        }
    }
}