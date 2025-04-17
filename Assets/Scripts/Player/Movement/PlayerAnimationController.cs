using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player.Movement
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimationController : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayWalkAnimation(Vector3 direction, float speed)
        {
            ChangeWalkingAnimationState(true);
        }

        public void PlayIdleAnimation()
        {
            ChangeWalkingAnimationState(false);
        }

        private void ChangeWalkingAnimationState(bool isWalking)
        {
            _animator.SetBool("isWalking", isWalking);
        }
    }
}