using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        transform.DOMove(target.position, speed); //much code, so optimized
    }
}
