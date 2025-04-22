using Assets.Scripts.Environment;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.AI
{
    public class VisitorSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private CheckoutCounter counter;
        [SerializeField] private float timeMin = 2f;
        [SerializeField] private float timeMax = 5f;

        private int _productionCount;
        private Coroutine _spawnRoutine;

        private void Start()
        {
            _spawnRoutine = StartCoroutine(SpawnRoutine());
        }

        private IEnumerator SpawnRoutine()
        {
            yield return new WaitUntil(() => InteractableFinder.Instance.GetListCount() > 0);

            while (true)
            {
                SpawnVisitor();
                float delay = Random.Range(timeMin, timeMax);
                yield return new WaitForSeconds(delay);
            }
        }

        private void SpawnVisitor()
        {
            var visitor = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
            _productionCount = NewProductionCount();
            visitor.GetComponent<VisitorAI>().Init(spawnPoint, _productionCount, counter);
        }

        private int NewProductionCount()
        {
            return Random.Range(1, InteractableFinder.Instance.GetListCount());
        }
    }
}