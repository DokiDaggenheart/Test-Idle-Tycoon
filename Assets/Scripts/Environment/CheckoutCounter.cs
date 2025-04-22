using UnityEngine;

namespace Assets.Scripts.Environment
{
    [RequireComponent(typeof(InteractionQueue))]
    public class CheckoutCounter : InteractableBase, IDurationChangeable
    {
        private float _durationMultiplier = 1;
        private bool _isCashierPresent;

        private void Awake()
        {
            interactionQueue = GetComponent<InteractionQueue>();
        }

        public override float GetInteractionDuration()
        {
            return interactionBasicDuration * _durationMultiplier;
        }

        public override Vector3 GetInteractionPoint()
        {
            return transform.position + transform.forward * 0.5f;
        }

        public void SetCashierPresence(bool present)
        {
            _isCashierPresent = present;
        }

        public bool CanStartInteraction()
        {
            return _isReserved && _isCashierPresent;
        }

        public void MarkInteractionStarted()
        {
            _isReserved = true;
        }

        public override bool TryReserve()
        {
            if (_isReserved) return false;
            MarkInteractionStarted();
            return true;
        }

        public override void Release()
        {
            _isReserved = false;
        }

        public void SetDurationMultiplier(float newMultiplier)
        {
            _durationMultiplier = newMultiplier;
        }
    }
}