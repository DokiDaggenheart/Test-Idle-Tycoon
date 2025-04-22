using Assets.Scripts.AI;
using Assets.Scripts.Environment;
using UnityEngine;

namespace Assets.Scripts.Building
{
    public class BuildingController : MonoBehaviour, IBuildingController
    {
        private Camera mainCamera;
        private BuildingModel _model;
        private BuildingView _view;
        private IBuildingInput _input;

        public void Initialize(Camera camera, BuildingModel model, BuildingView view, IBuildingInput input)
        {
            mainCamera = camera;
            _model = model;
            _view = view;
            _input = input;

            _input.OnRotateLeft += () => Rotate(-1);
            _input.OnRotateRight += () => Rotate(1);
            _input.OnCancelBuild += CancelBuilding;
            _input.OnConfirmBuild += TryPlaceBuilding;
        }

        public void StartBuilding(GameObject prefab)
        {
            if (_model.SelectedPrefab != null)
                return;
            _model.SetSelectedPrefab(prefab);
            _view.ShowPreview(prefab);
        }

        private void TryPlaceBuilding()
        {
            if (_model.SelectedPrefab == null) return;

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);

            foreach (var hit in hits)
            {
                if (hit.collider.CompareTag("Floor"))
                {
                    Vector3 snapPos = _model.GetSnappedPosition(hit.point);
                    _view.UpdatePreviewPosition(snapPos);

                    PlaceBuilding(_view.GetPreviewTransform());
                    break;
                }
            }
        }

        private void PlaceBuilding(Transform previewTransform)
        {
            if (!_view.CanBuild) return;

            var interactableObject =Instantiate(_model.SelectedPrefab, previewTransform.position, previewTransform.rotation);
            _view.HidePreview();
            _model.SetSelectedPrefab(null);
            InteractableFinder.Instance.RegisterInteractable(interactableObject.GetComponent<InteractableItem>());
        }

        private void CancelBuilding()
        {
            if (_view.HasPreview)
            {
                _view.HidePreview();
                _model.DeleteSelectedPrefab();
            }
        }

        private void Rotate(int direction)
        {
            if (_view.HasPreview)
            {
                _view.RotatePreview(90f * direction);
            }
        }

        private void Update()
        {
            if (_model?.SelectedPrefab == null) return;

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);

            foreach (var hit in hits)
            {
                if (hit.collider.CompareTag("Floor"))
                {
                    Vector3 snapPos = _model.GetSnappedPosition(hit.point);
                    _view.UpdatePreviewPosition(snapPos);
                    break;
                }
            }
        }
    }
}