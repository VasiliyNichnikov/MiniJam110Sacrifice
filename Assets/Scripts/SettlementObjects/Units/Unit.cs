using ClickObjects;
using SettlementObjects.Builders;
using SettlementObjects.Errors;
using SettlementObjects.Units.StatePattern;
using SettlementObjects.Units.StatePattern.States;
using UnityEngine;
using UnityEngine.AI;

namespace SettlementObjects.Units
{
    public abstract class Unit : ObjectToSelect
    {
        public IdleState Idle;
        public MovementState Movement;

        public (IClickObject clickedObject, Vector3 position) Action { get; private set; }
        public IBuilder BuilderWork { get; private set; }
        public NavMeshAgent Agent => _agent;
        public Animator Animator => _animator;

        private StateMachine _stateMachine;
        private Animator _animator;
        private NavMeshAgent _agent;

        public override void Start()
        {
            base.Start();
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
            
            Action = (new NoneObject(), Vector3.zero);
            
            // Инициализация состояний
            _stateMachine = new StateMachine();
            Idle = new IdleState(this, _stateMachine);
            Movement = new MovementState(this, _stateMachine);
            _stateMachine.Initialize(Idle);
        }

        public void SetParametersAction((IClickObject clickedObject, Vector3 position) selectedAction)
        {
            BuilderWork?.UnsubscribeToWork(this);
            BuilderWork = null;
            try
            {
                BuilderWork = GetBuilderForWork(selectedAction);
                selectedAction.position = BuilderWork.SubscribeToJob(this);
            }
            catch (ObjectIsNotBuilding)
            {
                
            }
            Action = selectedAction;
        }

        public void ResetParametersAction()
        {
            Action = (new NoneObject(), Vector3.zero);
        }
        
        private void Update()
        {
            _stateMachine.CurrentState.HandleInput();
            _stateMachine.CurrentState.LogicUpdate();
        }
        
        private IBuilder GetBuilderForWork((IClickObject clickedObject, Vector3 position) selectedAction)
        {
            if (selectedAction.clickedObject.IsWork == false)
            {
                throw new ObjectIsNotBuilding();
            }
                
            
            if (selectedAction.clickedObject is IBuilder build)
            {
                return build;
            }
            throw new ObjectIsNotBuilding();
        }
        
        private void OnDrawGizmos()
        {
            if (Action.position != Vector3.zero)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawSphere(Action.position, .2f);
                Gizmos.DrawLine(Action.position, ThisTransform.position);
            }
        }
    }
}