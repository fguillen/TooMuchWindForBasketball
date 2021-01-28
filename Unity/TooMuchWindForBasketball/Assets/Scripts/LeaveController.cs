using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveController : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [SerializeField] Vector2 timeToLiveLimits;
    LeafOnTheCameraController leafOnTheCameraController;
    float timeToLiveCounter;

    bool isSticky;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {    
        isSticky = true;
        timeToLiveCounter = Random.Range(timeToLiveLimits.x, timeToLiveLimits.y);

        leafOnTheCameraController = GetComponent<LeafOnTheCameraController>();
    }

    void Update()
    {
        if(isSticky)
        {
            CheckTimeToLive();
        }
    }

    void CheckTimeToLive(){
        timeToLiveCounter -= Time.deltaTime;

        if(timeToLiveCounter <= 0)
        {
            LetItGo();
        }
            
    }

    void LetItGo()
    {
        isSticky = false;

        if(leafOnTheCameraController.enabled && Random.Range(0, 20) == 0)
        {
            GoToTheCamera();
        } else {
            gameObject.layer = LayerMask.NameToLayer("NoStickyLeaves");
        }
    }

    void GoToTheCamera()
    {
        leafOnTheCameraController.GoToCamera();
    }

}
