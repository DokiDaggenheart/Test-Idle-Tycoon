using UnityEngine;

namespace Assets.Scripts.Environment
{
    public abstract class InteractableBase : MonoBehaviour, IInteractable
    {
        [SerializeField] protected float interactionBasicDuration;
        [SerializeField] protected Vector3 interactionPoint;
        [SerializeField] protected bool supportsQueue;
        [SerializeField] protected InteractionQueue interactionQueue;
        [SerializeField] protected int cost;

        protected bool _isReserved;

        public virtual bool TryReserve()
        {
            if (_isReserved) return false;
            _isReserved = true;
            return true;
        }

        public virtual void Release()
        {
            _isReserved = false;
        }

        public virtual bool IsAvailable() => !_isReserved;

        public virtual Vector3 GetInteractionPoint() => interactionPoint;

        public virtual float GetInteractionDuration() => interactionBasicDuration;

        public virtual bool SupportsQueue() => supportsQueue;

        public virtual InteractionQueue GetQueue() => interactionQueue;
        public virtual int GetCost() => cost;
    }
}