using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject ball;    
    [SerializeField] GameObject ballHandler;

    [SerializeField] int points;

    [SerializeField] float ballImpulse;

    public static PlayerController instance;
    bool hasBall;

    // Start is called before the first frame update
    void Start()
    {
        hasBall = false;
        instance = this;

        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUpBall()
    {
        ball.transform.parent = ballHandler.transform;
        ball.transform.position = ballHandler.transform.position;
        ball.GetComponent<BallController>().StopGravity();
        hasBall = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");

        if(collision.gameObject.CompareTag("Ball"))
        {
            PickUpBall();
        }
    }

    public void ShootBall()
    {
        if(hasBall)
        {
            Vector3 direction = new Vector3(-0.8f, 0.9f, 0f);

            ball.transform.parent = null;
            ball.GetComponent<BallController>().Shoot(direction, ballImpulse);
        }
    }

    public void IncreasePoints()
    {
        points ++;
        CanvasController.instance.RenderPoints(points);
    }
}
