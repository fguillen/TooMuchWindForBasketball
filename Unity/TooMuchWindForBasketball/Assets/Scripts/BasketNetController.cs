using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketNetController : MonoBehaviour
{
    public static BasketNetController instance;
    Animator animator;

    void Start()
    {
        instance = this;
        animator = GetComponent<Animator>();
    }

    public void Move()
    {
        animator.SetTrigger("move");
    }
}
