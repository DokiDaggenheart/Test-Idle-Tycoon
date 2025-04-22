namespace Assets.Scripts.Player.ResourceSystem
{
    public class ResourceModel
    {
        public int Money { get; private set; }

        public ResourceModel(int startMoney)
        {
            Money = startMoney;
        }

        public bool CanAfford(int amount) => Money >= amount;

        public void AddMoney(int amount)
        {
            Money += amount;
        }

        public bool SpendMoney(int amount)
        {
            if (!CanAfford(amount)) return false;
            Money -= amount;
            return true;
        }
    }
}