using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsIndicatorController : MonoBehaviour
{

    WindTargetController windTargetController;
    Rigidbody2D rb;
    void Awake()
    {
        windTargetController = GetComponent<WindTargetController>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void WindTargetEnabled(bool value)
    {        
        if(value)
        {
            Invoke("Collapse", Random.Range(0, 2.5f));
        } else 
        {
            rb.isKinematic = true;
            windTargetController.enabled = false;
        }
    }

    public void Collapse()
    {
        rb.isKinematic = false;
        windTargetController.enabled = true;
        rb.AddTorque(Random.Range(-10f, -50f));
    }
}
