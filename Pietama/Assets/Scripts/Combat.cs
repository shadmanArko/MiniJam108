using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Combat : MonoBehaviour
{
    
    public UnityEvent onAttack;


    [SerializeField] private Animator punchAnimator;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onAttack.Invoke();
            punchAnimator.SetTrigger("Shoot");
        }
    }
    

    
}
