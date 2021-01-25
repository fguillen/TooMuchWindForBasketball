using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject ball;    
    [SerializeField] GameObject ballHandler;

    [SerializeField] int points;

    [SerializeField] float ballImpulse;

    public bool isLookingLeft;

    public static PlayerController instance;
    bool hasBall;

    // Start is called before the first frame update
    void Start()
    {
        hasBall = false;
        instance = this;

        points = 0;

        isLookingLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Remove this in production
        if(Input.GetKeyDown("x"))
        {
            PickUpBall();
        }
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
        if(collision.gameObject.CompareTag("Ball"))
        {
            PickUpBall();
        }
    }

    public void ShootBall(float angle, float force)
    {
        if(hasBall)
        {
            Vector3 direction = Quaternion.Euler(0f, 0f, angle) * new Vector3(1f, 0f, 0f);

            if(!isLookingLeft)
                direction = new Vector3(-direction.x, direction.y, direction.z);
            

            print("ShootBall: " + force + ", direction: " + direction + ", angle: " + angle);

            ball.transform.parent = null;
            ball.GetComponent<BallController>().Shoot(direction, force);
        }
    }

    public void IncreasePoints()
    {
        points ++;
        CanvasController.instance.RenderPoints(points);
    }
}
