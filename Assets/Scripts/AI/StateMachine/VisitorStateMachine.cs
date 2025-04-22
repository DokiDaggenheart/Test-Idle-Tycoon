namespace Assets.Scripts.AI
{
    public class VisitorStateMachine
    {
        private ICustomerState _currentState;

        public void ChangeState(ICustomerState newState)
        {
            _currentState?.Exit();
            _currentState = newState;
            _currentState.Enter();
        }

        public void Update()
        {
            _currentState?.Update();
        }
    }
}