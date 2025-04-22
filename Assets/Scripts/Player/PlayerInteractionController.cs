using Assets.Scripts.Environment;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerInteractionController : MonoBehaviour
    {
        [SerializeField] private float interactionRadius = 2f;

        private CheckoutCounter _nearbyCounter;
        private bool _isInZone = false;
        private bool _isActiveCashier = false;

        void Update()
        {
            if (_isInZone && Input.GetKeyDown(KeyCode.E))
            {
                ToggleCashierStatus();
            }
        }

        private void ToggleCashierStatus()
        {
            if (_nearbyCounter == null) 
                return;

            _isActiveCashier = !_isActiveCashier;
            _nearbyCounter.SetCashierPresence(_isActiveCashier);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out CheckoutCounter counter))
            {
                _nearbyCounter = counter;
                _isInZone = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out CheckoutCounter counter) && counter == _nearbyCounter)
            {
                if (_isActiveCashier)
                    counter.SetCashierPresence(false);

                _nearbyCounter = null;
                _isInZone = false;
                _isActiveCashier = false;
            }
        }
    }
}