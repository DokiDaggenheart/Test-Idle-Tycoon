using UnityEngine;

namespace Assets.Scripts.Environment
{
    public interface IInteractable
    {
        Vector3 GetInteractionPoint();
        bool TryReserve();
        void Release();
        float GetInteractionDuration();
        bool IsAvailable();
        bool SupportsQueue();
        InteractionQueue GetQueue();
        int GetCost();
    }
}
