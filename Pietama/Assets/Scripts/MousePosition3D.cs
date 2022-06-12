using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class MousePosition3D : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;
        private void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue))
            {
                transform.position = raycastHit.point;
            }
        }
    }
}