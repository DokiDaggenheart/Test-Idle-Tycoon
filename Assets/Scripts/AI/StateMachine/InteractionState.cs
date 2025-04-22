using Assets.Scripts.Environment;
using UnityEngine;

namespace Assets.Scripts.AI
{
    public class InteractionState : BaseState
    {
        private readonly IInteractable _target;
        private float _interactionDuration;
        private float _elapsedTime;
        private bool _isInteracting;
        private VisitorAI _visitor;

        public InteractionState(BehaviorContext context, VisitorStateMachine stateMachine, IInteractable target)
            : base(context, stateMachine)
        {
            _target = target;
        }

        public override void Enter()
        {
            _visitor = Context.MovementController.GetComponent<VisitorAI>();
            _interactionDuration = _target.GetInteractionDuration();

            Context.MovementController.Stop();

            if (_target.SupportsQueue())
                _target.GetQueue().Enqueue(_visitor);
            else
                TryStartInteraction();
        }

        public override void Update()
        {
            if (_isInteracting)
            {
                _elapsedTime += Time.deltaTime;
                if (_elapsedTime >= _interactionDuration)
                    FinishInteraction();
                return;
            }

            if (_target.SupportsQueue())
            {
                var queue = _target.GetQueue();
                bool isMyTurn = queue.Peek() == _visitor;
                bool isCloseEnough = Vector3.Distance(_visitor.transform.position, _target.GetInteractionPoint()) < 0.5f;

                if (isMyTurn && isCloseEnough)
                    TryStartInteraction();
            }
        }

        private void TryStartInteraction()
        {
            if (!_target.TryReserve()) 
                return;

            _isInteracting = true;
            _elapsedTime = 0f;
            Context.LoadingUI.StartLoading(_interactionDuration);
        }

        private void FinishInteraction()
        {
            if (_target.SupportsQueue())
                _target.GetQueue().Dequeue();

            Context.ProductCount--;
            Context.CollectedProducts.Add(_target);
            Context.Wallet.AddCost(_target.GetCost());
            _target.Release();

            StateMachine.ChangeState(new IdleState(Context, StateMachine));
        }
    }
}