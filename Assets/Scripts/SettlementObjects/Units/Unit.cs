using System.Collections;
using ClickObjects;
using SettlementObjects.Builders;
using SettlementObjects.Errors;
using SettlementObjects.Resource;
using SettlementObjects.Units.StatePattern;
using SettlementObjects.Units.StatePattern.States;
using Timer;
using UnityEngine;
using UnityEngine.AI;

namespace SettlementObjects.Units
{
    public abstract class Unit : ObjectToSelect
    {
        public IdleState Idle;
        public MovementState Movement;
        public LoggerState Logger;
        public FieldState Field;
        public DeadState Dead;

        public bool IsDied { get; private set; }

        public (IClickObject clickedObject, Vector3 position) Action { get; private set; }
        public NavMeshAgent Agent => _agent;
        public Animator Animator => _animator;
        public GameObject ToolAxe;

        [SerializeField, Header("Еда за приношение в жертву")]
        private ScriptableObject _meat;

        [SerializeField, Header("Дерево за приношение в жертву")]
        private ScriptableObject _tree;

        [SerializeField, Header("Кол-во еды и древесины за жертвоприношение"), Range(0, 30)]
        private int _income;
        
        private IBuilder _builderWork;
        private StateMachine _stateMachine;
        private Animator _animator;
        private NavMeshAgent _agent;

        public override void Start()
        {
            base.Start();
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
            
            Action = (new NoneObject(), Vector3.zero);
            
            // Выключение топара при старте
            ToolAxe.SetActive(false);
            
            // Инициализация состояний
            _stateMachine = new StateMachine();
            Idle = new IdleState(this, _stateMachine);
            Movement = new MovementState(this, _stateMachine);
            Logger = new LoggerState(this, _stateMachine);
            Field = new FieldState(this, _stateMachine);
            Dead = new DeadState(this, _stateMachine);
            _stateMachine.Initialize(Idle);
        }

        public void SetParametersAction((IClickObject clickedObject, Vector3 position) selectedAction)
        {
            // if (selectedAction.clickedObject == BuilderWork)
            // {
            //     print("they equel");
            //     return;
            // }
            
            _builderWork?.UnsubscribeToWork(this);
            _builderWork = null;
            try
            {
                _builderWork = GetBuilderForWork(selectedAction);
                selectedAction.position = _builderWork.SubscribeToJob(this);
                Action = selectedAction;
            }
            catch (AllSeatsAreOccupied)
            {
                ResetParametersAction();
            }
            catch (ObjectIsNotBuilder)
            {
                Action = selectedAction;
            }
        }

        public void ResetParametersAction()
        {
            Action = (new NoneObject(), Vector3.zero);
        }

        public void Die()
        {
            TurnOffSelection();
            IsDied = true;
            EventsUnit.RemoveObjectFromSelectedObjects(this);
            ResourceCreditingEvents.UpdateResourceFromVictim(_income, (IResource)_meat);
            ResourceCreditingEvents.UpdateResourceFromVictim(_income, (IResource)_tree);
            StartCoroutine(DestroyPerson());
        }
        
        
        private void Update()
        {
            if(IsDied) return;
            _stateMachine.CurrentState.HandleInput();
            _stateMachine.CurrentState.LogicUpdate();
        }
        
        private IBuilder GetBuilderForWork((IClickObject clickedObject, Vector3 position) selectedAction)
        {
            if (selectedAction.clickedObject.IsWork == false)
            {
                throw new ObjectIsNotBuilder();
            }
                
            
            if (selectedAction.clickedObject is IBuilder build)
            {
                return build;
            }
            throw new ObjectIsNotBuilder();
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
        
        private IEnumerator DestroyPerson()
        {
            var timer = new TimerDead(collectionTime: 2.5f);
            yield return timer.Coroutine();
            Destroy(gameObject);
        }
        
    }
}