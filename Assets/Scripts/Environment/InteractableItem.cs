using Assets.Scripts.Player.ResourceSystem;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Environment
{
    public class InteractableItem : InteractableBase
    {
        [SerializeField] private int upgradeBasicCost;
        [SerializeField] private string itemID;
        [SerializeField] private float productCostMultiplier;
        [SerializeField] private float upgradeCostMultiplier;
        private int _upgradeTier = 1;
        public string ItemID => itemID;

        public override Vector3 GetInteractionPoint()
        {
            return transform.position + transform.forward * 0.5f;
        }

        public void Upgrade()
        {
            int upgradeCost = Mathf.RoundToInt(upgradeBasicCost + (upgradeCostMultiplier * _upgradeTier));

            if (ResourceController.Instance.TrySpendMoney(upgradeCost))
            {
                cost = Mathf.RoundToInt(cost * productCostMultiplier);
                _upgradeTier++;
            }
        }
    }
}