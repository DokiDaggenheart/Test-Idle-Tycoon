namespace Assets.Scripts.AI
{
    public class BaseState : ICustomerState
    {
        protected readonly BehaviorContext Context;
        protected readonly VisitorStateMachine StateMachine;

        protected BaseState(BehaviorContext context, VisitorStateMachine stateMachine)
        {
            Context = context;
            StateMachine = stateMachine;
        }

        public virtual void Enter() { }
        public virtual void Update() { }
        public virtual void Exit() { }
    }
}
