using Assets.Scripts.Environment;
using Assets.Scripts.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.AI
{
    public class BehaviorContext
    {
        public NavMeshAgent Agent { get; }
        public Transform SpawnPoint { get; }
        public Wallet Wallet { get; }
        public InteractableFinder InteractableFinder { get; }
        public LoadingCircle LoadingUI { get; }
        public AIMovementController MovementController { get; }
        public int ProductCount { get; set; }
        public List<IInteractable> CollectedProducts{ get; set; }
        public CheckoutCounter CheckoutCounter { get; private set; }

        public BehaviorContext(
            NavMeshAgent agent,
            Transform spawnPoint,
            Wallet wallet,
            InteractableFinder interactableFinder,
            LoadingCircle loadingCircle,
            int productCount, 
            AIMovementController movementController,
            List<IInteractable> collectedProducts,
            CheckoutCounter сheckoutCounter)
        {
            Agent = agent;
            SpawnPoint = spawnPoint;
            Wallet = wallet;
            InteractableFinder = interactableFinder;
            LoadingUI = loadingCircle;
            ProductCount = productCount;
            MovementController = movementController;
            CollectedProducts = collectedProducts;
            CheckoutCounter = сheckoutCounter;
        }
    }
}
