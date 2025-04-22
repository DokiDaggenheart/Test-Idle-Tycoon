using TMPro;
using UnityEngine;

namespace Assets.Scripts.Player.ResourceSystem
{
    public class ResourceView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI moneyText;

        public void UpdateMoneyDisplay(int money)
        {
            string moneyView;

            if (money < 1000)
                moneyView = money.ToString();
            else
                moneyView = (money / 1000f).ToString("0.0") + "K";

            moneyText.text = moneyView;
        }
    }
}