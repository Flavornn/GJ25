using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeAnimator : MonoBehaviour
{
    private Animator animator;
    private float timer = 1f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        //PlayAnimation();
    }


    public void PlayAnimation()
    {
        animator.SetTrigger("PLAY");
        timer = 1f;
    }
}
