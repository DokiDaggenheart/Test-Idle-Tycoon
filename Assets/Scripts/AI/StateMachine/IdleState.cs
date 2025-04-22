namespace Assets.Scripts.AI
{
    public class IdleState : BaseState
    {
        public IdleState(BehaviorContext context, VisitorStateMachine stateMachine)
        : base(context, stateMachine) { }

        public override void Enter()
        {
            if (Context.ProductCount == 0)
            {
                StateMachine.ChangeState(new FindCashRegisterState(Context, StateMachine));
            }
            else
            {
                StateMachine.ChangeState(new FindProductState(Context, StateMachine));
            }
        }
    }
}