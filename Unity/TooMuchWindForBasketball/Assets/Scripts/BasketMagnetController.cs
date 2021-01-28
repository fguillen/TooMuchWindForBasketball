using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketMagnetController : MonoBehaviour
{
    [SerializeField] Transform destiny;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Ball"))
        {
            if(other.GetComponent<Rigidbody2D>().velocity.y < 0)
                TrajectoryChange(other.gameObject);
        }
    }

    void TrajectoryChange(GameObject ball)
    {
        var velocity = ball.GetComponent<BallController>().rb.velocity;    
        var differenceNormalized = (destiny.position - ball.transform.position).normalized;
        var finalVelocity = velocity.magnitude * differenceNormalized;

        ball.GetComponent<BallController>().rb.velocity = finalVelocity;
    }
}
