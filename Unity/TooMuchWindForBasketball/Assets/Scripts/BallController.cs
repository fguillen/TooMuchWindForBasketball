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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
