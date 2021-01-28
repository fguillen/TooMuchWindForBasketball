using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    WindTargetController windTargetController;
    Rigidbody2D rb;
    void Start()
    {
        windTargetController = GetComponent<WindTargetController>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void WindTargetEnabled(bool value)
    {
        rb.isKinematic = !value;
        windTargetController.enabled = value;

        if(value)
            rb.AddTorque(-100f);
    }
}
