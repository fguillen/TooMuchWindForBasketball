using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveController : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [SerializeField] Vector2 timeToLiveLimits;
    float timeToLiveCounter;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        timeToLiveCounter = Random.Range(timeToLiveLimits.x, timeToLiveLimits.y);
    }

    void Update()
    {
        CheckTimeToLive();
    }

    void CheckTimeToLive(){
        timeToLiveCounter -= Time.deltaTime;

        if(timeToLiveCounter <= 0)
            gameObject.layer = LayerMask.NameToLayer("OldLeaves");
    }

}
