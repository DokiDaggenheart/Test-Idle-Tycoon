using Assets.Scripts.Environment;
using Assets.Scripts.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.AI
{
    public class VisitorAI : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private LoadingCircle loadingCircle;
        private Transform _spawnPoint;
        private int _productCount;
        private CheckoutCounter _counter;
        private BehaviorContext _context;
        private VisitorStateMachine _stateMachine;

        public void Init(Transform spawnpoint, int productionCount, CheckoutCounter counter)
        {
            _spawnPoint = spawnpoint;
            _productCount = productionCount;
            _counter = counter;
        }

        private void Start()
        {
            _context = new BehaviorContext(agent, _spawnPoint, new Wallet(), InteractableFinder.Instance, loadingCircle, _productCount, GetComponent<AIMovementController>(), new List<IInteractable>(), _counter);
            _stateMachine = new VisitorStateMachine();

            var searchState = new FindProductState(_context, _stateMachine);
            _stateMachine.ChangeState(searchState);
        }

        private void Update()
        {
            _stateMachine.Update();
        }
    }
}