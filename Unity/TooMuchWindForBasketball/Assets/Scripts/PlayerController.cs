using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject ball;    
    [SerializeField] GameObject ballHandler;
    [SerializeField] Transform points2;
    [SerializeField] Transform points3;

    [SerializeField] int points;

    [SerializeField] float ballImpulse;

    public bool isLookingLeft;

    public static PlayerController instance;
    public bool hasTheBallCaught { get; set; }

    Rigidbody2D rb;

    WindTargetController windTargetController;

    PlayerMovementController playerMovementController;
    PlayerImpulseController playerImpulseController;

    void Awake()
    {
        windTargetController = GetComponent<WindTargetController>();
        rb = GetComponent<Rigidbody2D>();        
        playerMovementController = GetComponent<PlayerMovementController>();
        playerImpulseController = GetComponent<PlayerImpulseController>();
    }
    void Start()
    {
        hasTheBallCaught = false;
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
        ball.GetComponent<BallController>().Hold();
        hasTheBallCaught = true;
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
        if(hasTheBallCaught)
        {
            hasTheBallCaught = false;

            Vector3 direction = Quaternion.Euler(0f, 0f, angle) * new Vector3(0f, 1f, 0f);

            if(!isLookingLeft)
                direction = new Vector3(-direction.x, direction.y, direction.z);
            
            ball.transform.parent = null;
            ball.GetComponent<BallController>().Shoot(direction, force);   

            LevelsController.instance.IncreseTries();         
        }
    }

    public void IncreasePoints()
    {
        points += CalculatePoints();
        CanvasController.instance.RenderPoints(points);
    }

    int CalculatePoints()
    {
        if(transform.position.x > points3.position.x)
            return 3;

        if(transform.position.x > points2.position.x)
            return 2;
        
        return 1;
    }

    public void WindTargetEnabled(bool value)
    {
        windTargetController.enabled = value;

        playerMovementController.enabled = !value;
        playerImpulseController.enabled = !value;

        // Set Constraints
        if(value)
            rb.constraints = RigidbodyConstraints2D.None;
        else 
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        // Torque
        if(value)
            rb.AddTorque(-100f);        

        // Change the Ball Layer
        if(value)
        {
            if(
                BallController.instance != null &&
                BallController.instance.gameObject.layer != LayerMask.NameToLayer("BallFree"))
            {
                BallController.instance.SetLayer("BallFree");
            }
        }
        else
        {
            if(
                BallController.instance != null &&
                BallController.instance.gameObject.layer != LayerMask.NameToLayer("Ball")
            )
            {
                BallController.instance.SetLayer("Ball");
            }
        }

        // ShootBall
        if(value)
            ShootBall(0f, 700f);
    }
}
