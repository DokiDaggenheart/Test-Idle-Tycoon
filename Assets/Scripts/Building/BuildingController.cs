using UnityEngine;

namespace Assets.Scripts.Building
{
    public class BuildingController : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private float gridSize = 1f;
        [SerializeField] private GameObject testPrefab;
        [SerializeField] private Material transparentMaterial;
        private BuildingModel _model;
        private BuildingView _view;

        private void Awake()
        {
            _model = new BuildingModel(gridSize);
            _view = new BuildingView(transparentMaterial);
        }

        public void StartBuilding(GameObject prefab)
        {
            _model.SetSelectedPrefab(prefab);
            _view.ShowPreview(prefab);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                StartBuilding(testPrefab);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Rotate(-1);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Rotate(1);
            }
            if (Input.GetKeyDown(KeyCode.X))
            {
                CancelBuilding();
            }

            if (_model.SelectedPrefab == null) return;

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);

            foreach (var hit in hits)
            {
                if (hit.collider.CompareTag("Floor"))
                {
                    Vector3 snapPos = _model.GetSnappedPosition(hit.point);
                    _view.UpdatePreviewPosition(snapPos);

                    if (Input.GetMouseButtonDown(0))
                        PlaceBuilding(_view.GetPreviewTransform());

                    break;
                }
            }

        }

        private void PlaceBuilding(Transform previewTransform)
        {
            if (!_view.CanBuild)
                return;

            Instantiate(_model.SelectedPrefab, previewTransform.position, previewTransform.rotation);
            _view.HidePreview();
            _model.SetSelectedPrefab(null);
        }

        private void CancelBuilding()
        {
            if (_view.HasPreview)
            {
                _view.HidePreview();
                _model.DeleteSelectedPrefab();
            }
        }

        /// <summary>
        /// Rotates the building preview in the specified direction.
        /// </summary>
        /// <param name="direction"> "-1" - to the left, 1 - to the right .</param>
        private void Rotate(int direction)
        {
            if (_view.HasPreview)
            {
                _view.RotatePreview(90f*direction);
            }
        }
    }
}