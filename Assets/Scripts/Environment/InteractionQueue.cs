using Assets.Scripts.AI;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Environment
{
    public class InteractionQueue : MonoBehaviour
    {
        [SerializeField] private Transform[] queuePoints;

        private Queue<VisitorAI> _queue = new Queue<VisitorAI>();

        public void Enqueue(VisitorAI visitor) => _queue.Enqueue(visitor);

        public VisitorAI Peek() => _queue.Count > 0 ? _queue.Peek() : null;

        public VisitorAI Dequeue() => _queue.Count > 0 ? _queue.Dequeue() : null;

        public int Count => _queue.Count;

        public VisitorAI GetPrevious(VisitorAI visitor)
        {
            var list = _queue.ToArray();
            for (int i = 1; i < list.Length; i++)
            {
                if (list[i] == visitor)
                    return list[i - 1];
            }
            return null;
        }
    }
}