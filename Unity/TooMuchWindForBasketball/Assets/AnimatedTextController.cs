using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedTextController : MonoBehaviour
{
    Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();

        Invoke("StartAnimation", Random.Range(0f, 0.5f));
    }

    void StartAnimation()
    {
        animator.SetTrigger("startMoving");
    }
}
