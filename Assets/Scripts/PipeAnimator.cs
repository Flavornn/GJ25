using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeAnimator : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        //PlayAnimation();
    }


    public void PlayAnimation()
    {
        animator.SetTrigger("PLAY");
    }
}
