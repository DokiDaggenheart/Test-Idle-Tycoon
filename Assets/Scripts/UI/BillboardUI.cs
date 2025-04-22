using System.Collections;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class BillboardUI : MonoBehaviour
    {
        private Camera cam;

        void Start()
        {
            cam = Camera.main;
        }

        void LateUpdate()
        {
            if (cam != null)
            {
                Vector3 lookDirection = transform.position - cam.transform.position;
                lookDirection.y = 0f;
                transform.rotation = Quaternion.LookRotation(lookDirection);
            }
        }
    }
}