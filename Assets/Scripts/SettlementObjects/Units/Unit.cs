using ClickObjects;
using SelectedObjects.Units.StatePattern;
using SettlementObjects.Units.StatePattern.States;
using Units;
using UnityEngine;
using UnityEngine.AI;

namespace SettlementObjects.Units
{
    public abstract class Unit : ObjectToSelect
    {
        public IdleState Idle;
        public WalkingState Walking;
        public (IClickObject hit, Vector3 position) Click { get; private set; }
        public override TypesOfObjects TypeObject => TypesOfObjects.Unit;
        public NavMeshAgent Agent => _agent;
        // public Animator Animator => _animator;

        private StateMachine _stateMachine;
        // private Animator _animator;
        private NavMeshAgent _agent;

        public override void Start()
        {
            base.Start();
            _agent = GetComponent<NavMeshAgent>();
            // _animator = GetComponent<Animator>();
            
            Click = (new NoneObject(), Vector3.zero);
            
            // Инициализация состояний
            _stateMachine = new StateMachine();
            Idle = new IdleState(this, _stateMachine);
            Walking = new WalkingState(this, _stateMachine);
            _stateMachine.Initialize(Idle);
        }

        public void SetClick((IClickObject hit, Vector3 position) click)
        {
            Click = click;
        }

        public void ResetClick()
        {
            Click = (new NoneObject(), Vector3.zero);
        }
        
        private void Update()
        {
            _stateMachine.CurrentState.HandleInput();
            _stateMachine.CurrentState.LogicUpdate();
        }

        private void OnDrawGizmos()
        {
            if (Click.position != Vector3.zero)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawSphere(Click.position, .2f);
                Gizmos.DrawLine(Click.position, ThisTransform.position);
            }
        }
    }
}