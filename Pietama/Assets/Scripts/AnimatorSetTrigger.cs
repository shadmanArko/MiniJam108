using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSetTrigger : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string[] triggers;

    public void SetTrigger(int trigger)
    {
        animator.SetTrigger(triggers[trigger]);
    }
}
