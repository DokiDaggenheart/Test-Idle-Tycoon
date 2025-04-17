using UnityEngine;

namespace Assets.Scripts.Building
{
    public class BuildingModel
    {
        public GameObject SelectedPrefab { get; private set; }
        public float GridSize { get; }

        public BuildingModel(float gridSize)
        {
            GridSize = gridSize;
        }

        public void SetSelectedPrefab(GameObject prefab)
        {
            SelectedPrefab = prefab;
        }

        public void DeleteSelectedPrefab()
        {
            SelectedPrefab = null;
        }
        
        public Vector3 GetSnappedPosition(Vector3 rawPosition)
        {
            float g = GridSize;
            return new Vector3(
                Mathf.Round(rawPosition.x / g) * g,
                Mathf.Round(rawPosition.y / g) * g,
                Mathf.Round(rawPosition.z / g) * g
            );
        }
    }
}