using Assets.Scripts.Environment;
using Assets.Scripts.Inventory;
using Assets.Scripts.Player.ResourceSystem;
using UnityEngine;

namespace Assets.Scripts.UI.Inventory
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private ItemData basicItem;
        [SerializeField] private CheckoutCounter counter;
        private InventoryModel _model;
        private InventoryView _view;

        void Awake()
        {
            _model = new InventoryModel(counter);
            _view = GetComponent<InventoryView>();
            _view.Init(_model.Equip, Craft);
        }

        public void BuyNewItem()
        {
            if(_model.BuyItem(basicItem))
                _view.SetItems(_model.Items);
        }

        public void Craft(ItemData baseItem)
        {
            if(_model.TryCraft(baseItem))
                _view.SetItems(_model.Items);
        }
    }
}