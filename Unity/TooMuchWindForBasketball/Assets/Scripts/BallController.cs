using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public static BallController instance;
    Rigidbody2D rb;

    void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    public void StopGravity()
    {
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
    }

    public void Shoot(Vector3 direction, float impulse)
    {
        rb.isKinematic = false;
        rb.AddForce(direction * impulse);
    }


}
