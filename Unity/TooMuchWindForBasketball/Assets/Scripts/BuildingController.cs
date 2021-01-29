using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    WindTargetController windTargetController;
    Rigidbody2D rb;
    AudioSource audioSource;

    void Awake()
    {
        windTargetController = GetComponent<WindTargetController>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    public void WindTargetEnabled(bool value)
    {        
        if(value)
        {
            Invoke("Collapse", Random.Range(0, 4));
        } else 
        {
            rb.isKinematic = true;
            windTargetController.enabled = false;
        }
    }

    public void Collapse()
    {
        audioSource.Play();

        rb.isKinematic = false;
        windTargetController.enabled = true;
        rb.AddTorque(Random.Range(-50f, -100f));
    }
}
