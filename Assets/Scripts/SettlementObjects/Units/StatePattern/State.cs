using SelectedObjects.Units.StatePattern;

namespace SettlementObjects.Units.StatePattern
{
    public abstract class State
    {
        protected Unit Unit;
        protected StateMachine StateMachine;

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
    }
}