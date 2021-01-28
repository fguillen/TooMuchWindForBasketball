using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public static BallController instance;
    public Rigidbody2D rb;
    WindTargetController windTargetController;
    Collider2D theCollider;

    void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        windTargetController = GetComponent<WindTargetController>();
        theCollider = GetComponent<Collider2D>();
    }

    public void Hold()
    {
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        windTargetController.enabled = false;
        theCollider.enabled = false;
    }

    public void Shoot(Vector3 direction, float impulse)
    {
        rb.isKinematic = false;
        rb.AddForce(direction * impulse);
        windTargetController.enabled = true;
        theCollider.enabled = true;
    }

    public void SetLayer(string name)
    {
        gameObject.layer = LayerMask.NameToLayer(name);
    }
}
