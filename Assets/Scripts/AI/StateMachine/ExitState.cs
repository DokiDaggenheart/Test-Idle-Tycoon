using UnityEngine;

namespace Assets.Scripts.AI
{
    public class ExitState : BaseState
    {
        public ExitState(BehaviorContext context, VisitorStateMachine stateMachine)
        : base(context, stateMachine) { }

        public override void Enter()
        {
            Context.MovementController.Stop();
            Context.MovementController.MoveTo(Context.SpawnPoint.position);
        }

        public override void Update()
        {
            if (!Context.MovementController.IsMoving)
                Object.Destroy(Context.MovementController.gameObject);
        }
    }
}