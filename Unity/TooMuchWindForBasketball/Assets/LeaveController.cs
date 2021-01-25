using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveController : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [SerializeField] float timeToLive;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckTimeToLive();
    }

    void CheckTimeToLive(){
        timeToLive -= Time.deltaTime;

        if(timeToLive <= 0)
            gameObject.layer = LayerMask.NameToLayer("OldLeaves");
    }

}
