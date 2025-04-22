using Assets.Scripts.Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Inventory
{
    public class ItemSlotView : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private Button craftButton;
        [SerializeField] private Button equipButton;

        private ItemData _item;

        public void Setup(ItemData item, System.Action<ItemData> onEquip, System.Action<ItemData> onCraft)
        {
            _item = item;
            icon.sprite = item.icon;

            craftButton.onClick.RemoveAllListeners();
            craftButton.onClick.AddListener(() => onCraft?.Invoke(_item));

            equipButton.onClick.RemoveAllListeners();
            equipButton.onClick.AddListener(() => onEquip?.Invoke(_item));
        }
    }
}