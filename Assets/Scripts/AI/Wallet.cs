using Assets.Scripts.Player.ResourceSystem;

namespace Assets.Scripts.AI
{
    public class Wallet
    {
        public int TotalCost { get; private set; }

        public void AddCost(int amount)
        {
            if (amount <= 0) return;

            TotalCost += amount;
        }

        public void Pay()
        {
            ResourceController.Instance.AddMoney(TotalCost);
        }
    }
}