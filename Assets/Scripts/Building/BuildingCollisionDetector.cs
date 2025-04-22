using UnityEngine;

namespace Assets.Scripts.Building
{
    public class BuildingCollisionDetector : MonoBehaviour
    {
        public bool IsBlocked => _blockingCount > 0;

        private int _blockingCount = 0;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Environment"))
                _blockingCount++;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Environment"))
                _blockingCount = Mathf.Max(0, _blockingCount - 1);
        }
    }
}