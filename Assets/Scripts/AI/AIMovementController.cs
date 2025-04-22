using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.AI
{
    public class AIMovementController : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private Animator _animator;

        public bool IsMoving => _agent.remainingDistance > _agent.stoppingDistance;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
        }

        public void MoveTo(Vector3 destination)
        {
            _agent.SetDestination(destination);
            PlayWalkingAnimation(true);
        }

        public void Stop()
        {
            _agent.ResetPath();
            PlayWalkingAnimation(false);
        }

        private void PlayWalkingAnimation(bool isActive)
        {
            _animator.SetBool("isWalking", isActive);
        }
    }
}