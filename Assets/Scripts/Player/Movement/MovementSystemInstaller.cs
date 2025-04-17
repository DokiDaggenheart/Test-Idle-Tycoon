using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player.Movement
{
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(MovementView))]
    [RequireComponent(typeof(PlayerAnimationController))]
    [RequireComponent(typeof(IMovementInputProvider))]
    

    public class MovementSystemInstaller : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;

        private void Awake()
        {
            var controller = GetComponent<MovementController>();
            var view = GetComponent<MovementView>();
            var input = GetComponent<IMovementInputProvider>();
            var model = new MovementModel(moveSpeed);
            var animationController = GetComponent<PlayerAnimationController>();

            controller.Init(input, model);
            controller.OnWalk += view.Move;
            controller.OnWalk += animationController.PlayWalkAnimation;
            controller.OnStay += animationController.PlayIdleAnimation;
        }
    }
}