using UnityEngine;

namespace Assets.Scripts.Player.ResourceSystem
{
    public class ResourceController : MonoBehaviour
    {
        [SerializeField] private ResourceView view;
        [SerializeField] private int startMoney = 1000;

        private ResourceModel _model;

        public static ResourceController Instance { get; private set; }

        public int GetCurrentMoney() => _model.Money;

        private void Awake()
        {
            Instance = this;
            _model = new ResourceModel(startMoney);
            view.UpdateMoneyDisplay(_model.Money);
        }

        public bool TrySpendMoney(int amount)
        {
            if (_model.SpendMoney(amount))
            {
                view.UpdateMoneyDisplay(_model.Money);
                return true;
            }

            return false;
        }

        public void AddMoney(int amount)
        {
            _model.AddMoney(amount);
            view.UpdateMoneyDisplay(_model.Money);
        }
    }
}