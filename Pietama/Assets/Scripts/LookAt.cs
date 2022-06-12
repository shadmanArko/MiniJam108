using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class LookAt : MonoBehaviour
    {
        private GameObject _target;

        private void Start()
        {
            _target = GameObject.Find("MousePosition3D");
        }

        private void Update()
        {
            transform.LookAt(_target.transform);
        }
    }
}