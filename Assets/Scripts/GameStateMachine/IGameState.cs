namespace Assets.Scripts.GameStateMachine
{
    public interface IGameState
    {
        void Enter();
        void Exit();
        void Update();
    }
}