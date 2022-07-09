using UnityEngine;

namespace SettlementObjects.Units.StatePattern
{
    public class StateMachine
    {
        public State CurrentState { get; private set; }

        public void Initialize(State state)
        {
            CurrentState = state;
            CurrentState.Enter();
        }

        public void ChangeState(State newState)
        {
            MonoBehaviour.print($"Current state: {CurrentState}");
            CurrentState.Exit();

            CurrentState = newState;
            newState.Enter();
        }
    }
}