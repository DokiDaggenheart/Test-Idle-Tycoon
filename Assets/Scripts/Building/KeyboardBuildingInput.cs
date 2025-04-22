using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Building
{
public class KeyboardBuildingInput : MonoBehaviour, IBuildingInput
    {
        public event System.Action OnStartBuild;
        public event System.Action OnRotateLeft;
        public event System.Action OnRotateRight;
        public event System.Action OnCancelBuild;
        public event System.Action OnConfirmBuild;

        [SerializeField] private KeyCode buildKey = KeyCode.G;
        [SerializeField] private KeyCode rotateLeftKey = KeyCode.Q;
        [SerializeField] private KeyCode rotateRightKey = KeyCode.E;
        [SerializeField] private KeyCode cancelKey = KeyCode.X;
        [SerializeField] private KeyCode confirmKey = KeyCode.Mouse0;

        private void Update()
        {
            if (Input.GetKeyDown(buildKey)) OnStartBuild?.Invoke();
            if (Input.GetKeyDown(rotateLeftKey)) OnRotateLeft?.Invoke();
            if (Input.GetKeyDown(rotateRightKey)) OnRotateRight?.Invoke();
            if (Input.GetKeyDown(cancelKey)) OnCancelBuild?.Invoke();
            if (Input.GetKeyDown(confirmKey)) OnConfirmBuild?.Invoke();
        }
    }
}