using System;
using SettlementObjects.Builders;

namespace SettlementObjects.Units.StatePattern
{
    public abstract class State
    {
        protected readonly Unit Unit;
        protected readonly StateMachine StateMachine;

        protected State(Unit unit, StateMachine stateMachine)
        {
            Unit = unit;
            StateMachine = stateMachine;
        }

        public virtual void Enter()
        {
        }
        
        public virtual void HandleInput()
        {
        }
        
        public virtual void LogicUpdate()
        {
            
        }

        public virtual void Exit()
        {
            
        }
        
        protected IBuilder GetBuilderForWork()
        {
            if (Unit.Click.hit.IsAction == false)
                throw new Exception("This position is not buildable"); // todo отфлильтровать ошибку
            
            if (Unit.Click.hit is IBuilder build)
            {
                return build;
            }
            throw new Exception("This position is not buildable"); // todo отфлильтровать ошибку
        }
    }
}