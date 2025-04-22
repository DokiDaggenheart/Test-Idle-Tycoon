using Assets.Scripts.Environment;
using Assets.Scripts.Inventory;
using Assets.Scripts.Player.ResourceSystem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.UI.Inventory
{
    public class InventoryModel
    {
        public InventoryModel(IDurationChangeable counter)
        {
            _counter = counter;
        }

        public List<ItemData> Items { get; } = new();
        public ItemData EquippedItem { get; private set; }

        private IDurationChangeable _counter;

        public void Equip(ItemData item)
        {
            Debug.Log("Equip");
            if (Items.Contains(item))
            {
                EquippedItem = item;
                _counter.SetDurationMultiplier(GetServiceDurationModifier());
            }
        }

        public float GetServiceDurationModifier()
        {
            return EquippedItem?.serviceDurationModifier ?? 1f;
        }

        public void AddItem(ItemData item)
        {
            Items.Add(item);
        }

        public bool TryCraft(ItemData baseItem)
        {
            int count = Items.Count(i => i == baseItem);

            if (count >= 2 && baseItem.nextTierItem != null)
            {
                Items.Remove(baseItem);
                Items.Remove(baseItem);
                Items.Add(baseItem.nextTierItem);
                return true;
            }

            return false;
        }

        public bool BuyItem(ItemData item)
        {
            if (ResourceController.Instance.TrySpendMoney(item.baseCost))
            {
                Items.Add(item);
                return true;
            }
            return false;
        }
    }
}