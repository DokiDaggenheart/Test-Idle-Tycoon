using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Building
{
    public class BuildingView
    {
        public BuildingView(Material transparentMaterial)
        {
            _transparentMaterial = transparentMaterial;
        }

        public bool HasPreview => _previewInstance != null;
        public bool CanBuild => !_colisionDetector.IsBlocked;
        private Material _transparentMaterial;
        private GameObject _previewInstance;
        private MaterialSwapper _materialSwapper = new();
        private BuildingCollisionDetector _colisionDetector;

        public void ShowPreview(GameObject prefab)
        {
            _previewInstance = GameObject.Instantiate(prefab);
            _colisionDetector = _previewInstance.GetComponent<BuildingCollisionDetector>();
            SetTransparent(_previewInstance);
        }

        public Transform GetPreviewTransform()
        {
            return _previewInstance.transform;
        }

        public void UpdatePreviewPosition(Vector3 pos)
        {
            if (_previewInstance != null)
                _previewInstance.transform.position = pos;
        }

        public void RotatePreview(float angle)
        {
            if (_previewInstance != null)
                _previewInstance.transform.Rotate(Vector3.up, angle);
        }

        public void HidePreview()
        {
            if (_previewInstance != null)
            {
                GameObject.Destroy(_previewInstance);
                _colisionDetector = null;
            }
                
        }

        private void SetTransparent(GameObject obj)
        {
            foreach (var col in obj.GetComponentsInChildren<Collider>())
                col.isTrigger = true;

            _materialSwapper.ApplyTransparentMaterials(obj, _transparentMaterial);
        }
    }
}