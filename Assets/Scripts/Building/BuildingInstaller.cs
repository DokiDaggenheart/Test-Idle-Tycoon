using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Building
{
    public class BuildingInstaller : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private float gridSize = 1f;
        [SerializeField] private Material transparentMaterial;
        [SerializeField] private BuildingController controller;
        [SerializeField] private KeyboardBuildingInput keyboardInput; //Я тут очень хочу передать интерфейсом, но это намного удобнее делается через Zenject

        private void Awake()
        {
            var model = new BuildingModel(gridSize);
            var view = new BuildingView(transparentMaterial);

            controller.Initialize(mainCamera, model, view, keyboardInput);
        }
    }
}