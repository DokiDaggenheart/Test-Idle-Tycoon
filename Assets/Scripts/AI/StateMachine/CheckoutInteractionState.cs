using Assets.Scripts.Environment;
using Assets.Scripts.Player.ResourceSystem;
using UnityEngine;

namespace Assets.Scripts.AI
{
    public class CheckoutInteractionState : BaseState
    {
        private readonly CheckoutCounter _counter;
        private float _elapsedTime;
        private bool _isInteracting;
        private VisitorAI _visitor;

        public CheckoutInteractionState(BehaviorContext context, VisitorStateMachine stateMachine, CheckoutCounter counter)
            : base(context, stateMachine)
        {
            _counter = counter;
        }

        public override void Enter()
        {
            _visitor = Context.MovementController.GetComponent<VisitorAI>();
            if (!_counter.TryReserve())
            {
                StateMachine.ChangeState(new IdleState(Context, StateMachine));
                //Я очень хотел через очередь, но я и так просрочил дедлайн и немного тороплюсь)
            }

            Context.MovementController.Stop();
        }

        public override void Update()
        {
            if (_isInteracting)
            {
                _elapsedTime += Time.deltaTime;
                if (_elapsedTime >= _counter.GetInteractionDuration())
                    FinishInteraction();
                return;
            }

            if (_counter.CanStartInteraction())
            {
                _isInteracting = true;
                _elapsedTime = 0f;
                _counter.MarkInteractionStarted();
                Context.LoadingUI.StartLoading(_counter.GetInteractionDuration());
            }
        }

        private void FinishInteraction()
        {
            Context.Wallet.Pay();
            _counter.Release();

            Context.CollectedProducts.Clear();
            StateMachine.ChangeState(new ExitState(Context, StateMachine));
        }
    }
}