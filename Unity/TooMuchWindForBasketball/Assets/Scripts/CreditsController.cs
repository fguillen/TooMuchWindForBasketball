using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour
{
    public static CreditsController instance;
    Animator animator;

    void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
    }

    public void Show()
    {
        animator.SetBool("visible", true);
    }

    public void Hide()
    {
        animator.SetBool("visible", false);
    }
}
