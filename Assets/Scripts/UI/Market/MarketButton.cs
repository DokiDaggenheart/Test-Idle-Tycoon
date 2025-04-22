using Assets.Scripts.Building;
using Assets.Scripts.Player.ResourceSystem;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.Market
{
    public class MarketButton : MonoBehaviour
    {
        [SerializeField] private GameObject _buildingPrefab;
        [SerializeField] private BuildingController _buildController;
        [SerializeField] private int _price;
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private MarketController _marketController;

        private void Awake()
        {
            if (_priceText != null)
                _priceText.text = _price.ToString();
        }

        public void TryBuild()
        {
            if (ResourceController.Instance.TrySpendMoney(_price))
            {
                _buildController.StartBuilding(_buildingPrefab);
                _marketController.ToggleMarket();
            }
            else
            {
                Debug.Log("Not enough resources to build.");
            }
        }
    }
}