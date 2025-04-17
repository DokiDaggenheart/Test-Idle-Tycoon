using System;
using UnityEngine;

namespace Assets.Scripts.Player.Movement
{
    [RequireComponent(typeof(MovementView))]
    public class MovementController : MonoBehaviour
    {
        public event Action<Vector3, float> OnWalk;
        public event Action OnStay;

        private MovementModel _model;
        private IMovementInputProvider _input;

        public void Init(IMovementInputProvider input, MovementModel model)
        {
            _input = input;
            _model = model;
        }

        private void FixedUpdate()
        {
            Vector3 dir = _input.GetDirection();
            if (dir == Vector3.zero)
            {
                OnStay?.Invoke();
                return;
            }
            OnWalk?.Invoke(dir, _model.MoveSpeed);
        }
    }
}