using Assets.Scripts.Environment;

namespace Assets.Scripts.AI
{
    public class CashRegister
    {
        private readonly InteractionQueue _queue = new();

        public void EnqueueVisitor(VisitorAI visitor)
        {
            _queue.Enqueue(visitor);

        }

        public void ProcessPurchase()
        {

        }

        public void OnVisitorServed()
        {
            _queue.Dequeue();
        }
    }
}
