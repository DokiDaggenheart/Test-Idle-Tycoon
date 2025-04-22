using UnityEngine;

namespace Assets.Scripts.Inventory
{
    [CreateAssetMenu]
    public class ItemData : ScriptableObject
    {
        public string itemID;
        public string displayName;
        public Sprite icon;
        public float serviceDurationModifier;
        public int tier;
        public int baseCost;
        public ItemData nextTierItem;
    }
}