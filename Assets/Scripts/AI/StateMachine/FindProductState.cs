using Assets.Scripts.Environment;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.AI
{
    public class FindProductState : BaseState
    {
        private IInteractable _target;

        public FindProductState(BehaviorContext context, VisitorStateMachine stateMachine)
            : base(context, stateMachine) { }

        public override void Enter()
        {
            _target = Context.InteractableFinder.FindClosestAvailable(Context.MovementController.transform.position, Context.CollectedProducts);

            if (_target != null)
                Context.MovementController.MoveTo(_target.GetInteractionPoint());
        }

        public override void Update()
        {
            if (_target == null)
                return;

            if (!Context.MovementController.IsMoving)
            {
                StateMachine.ChangeState(new InteractionState(Context, StateMachine, _target));
            }
        }
    }
}