namespace Assets.Scripts.Player.Movement
{
    public class MovementModel 
    {
        public float MoveSpeed { get; private set; }

        public MovementModel(float moveSpeed)
        {
            MoveSpeed = moveSpeed;
        }
    }
}