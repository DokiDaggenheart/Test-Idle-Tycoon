using Assets.Scripts.Environment;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.AI
{
    public class InteractableFinder
    {
        private static InteractableFinder _instance;
        public static InteractableFinder Instance => _instance ??= new InteractableFinder();

        private List<IInteractable> _interactables = new();

        public void RegisterInteractable(IInteractable interactable)
        {
            if (!_interactables.Contains(interactable) && interactable != null)
            {
                _interactables.Add(interactable);
            }
        }

        public void UnregisterInteractable(IInteractable interactable)
        {
            _interactables.Remove(interactable);
        }

        public IInteractable FindClosestAvailable(Vector3 position, List<IInteractable> excluded = null)
        {
            float distanceWeight = 1f;
            float queueWeight = 5f;

            return _interactables
                .Where(i =>
                    (excluded == null || !excluded.Contains(i)) &&
                    (i.SupportsQueue() || i.IsAvailable())
                )
                .OrderBy(i =>
                {
                    float distance = Vector3.Distance(position, i.GetInteractionPoint());

                    int queueSize = i.SupportsQueue() && i.GetQueue() != null
                        ? i.GetQueue().Count
                        : (i.IsAvailable() ? 0 : 999);

            return (distance * distanceWeight) + (queueSize * queueWeight);
                })
                .FirstOrDefault();
        }

        public int GetListCount()
        {
            return _interactables.Count;
        }
    }
}
