using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Building
{
    public class MaterialSwapper
    {
        private readonly Dictionary<Renderer, Material[]> _originalMaterials = new();

        public void ApplyTransparentMaterials(GameObject target, Material transparentMaterial)
        {
            foreach (var renderer in target.GetComponentsInChildren<Renderer>())
            {
                if (!_originalMaterials.ContainsKey(renderer))
                    _originalMaterials[renderer] = renderer.sharedMaterials;

                Material[] transparentMats = new Material[renderer.materials.Length];
                for (int i = 0; i < transparentMats.Length; i++)
                    transparentMats[i] = transparentMaterial;

                renderer.materials = transparentMats;
            }
        }

        public void RestoreOriginalMaterials()
        {
            foreach (var kvp in _originalMaterials)
                kvp.Key.materials = kvp.Value;

            _originalMaterials.Clear();
        }
    }
}