using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform limitLeft;
    [SerializeField] Transform limitRight;
    [SerializeField] Transform figure;
    Rigidbody2D rb;
    Animator animator;
    float originalScaleX;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        originalScaleX = figure.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        if(horizontal < 0 && IsLeftLimitReached())
        {
            horizontal = 0;
        }

        if(horizontal > 0 && IsRightLimitReached())
        {
            horizontal = 0;
        }

        if(horizontal != 0)
        {
            animator.SetBool("walking", true);
        } else
        {
            animator.SetBool("walking", false);
        }

        // Flip
        if(horizontal < 0)
        {
            figure.transform.localScale = new Vector3(-originalScaleX, figure.transform.localScale.y, figure.transform.localScale.z);
        } else if(horizontal > 0)
        {
            figure.transform.localScale = new Vector3(originalScaleX, figure.transform.localScale.y, figure.transform.localScale.z);
        }

        // Actual move
        rb.velocity = new Vector2(horizontal * speed, 0);
    }

    bool IsLeftLimitReached()
    {
        return transform.position.x < limitLeft.position.x;
    }

    bool IsRightLimitReached()
    {
        return transform.position.x > limitRight.position.x;
    }
}
