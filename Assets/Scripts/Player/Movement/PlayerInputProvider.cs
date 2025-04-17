using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.Player.Movement
{
    public class PlayerInputProvider : MonoBehaviour, IMovementInputProvider
    {
        public Vector3 GetDirection()
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Vertical"), -Input.GetAxisRaw("Horizontal"));
            var direction = IsoUtils.ToIsoDirection(input).normalized;
            return direction;
        }
    }
}