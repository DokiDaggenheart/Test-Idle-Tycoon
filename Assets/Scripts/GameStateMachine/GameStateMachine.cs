namespace Assets.Scripts.GameStateMachine
{
    public class GameStateMachine
    {
        private IGameState _currentState;

        public void SetState(IGameState newState)
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
