using UnityEngine;

namespace Assets.Scripts.Player.Movement
{
    public interface IMovementInputProvider
    {
        Vector3 GetDirection();
    }
}