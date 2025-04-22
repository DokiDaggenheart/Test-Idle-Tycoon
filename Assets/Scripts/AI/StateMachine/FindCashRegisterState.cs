using Assets.Scripts.Environment;
using UnityEngine;

namespace Assets.Scripts.AI
{
    public class FindCashRegisterState : BaseState
    {
        private CheckoutCounter _target;

        public FindCashRegisterState(BehaviorContext context, VisitorStateMachine stateMachine)
            : base(context, stateMachine) { }

        public override void Enter()
        {

            _target = Context.CheckoutCounter;

            if (_target != null)
                Context.MovementController.MoveTo(_target.GetInteractionPoint());
        }

        public override void Update()
        {
            if (_target == null)
                return;

            if (!Context.MovementController.IsMoving)
            {
                StateMachine.ChangeState(new CheckoutInteractionState(Context, StateMachine, _target));
            }
        }
    }
}