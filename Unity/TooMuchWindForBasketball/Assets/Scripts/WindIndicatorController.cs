using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindIndicatorController : MonoBehaviour
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
        rb.isKinematic = !value;
        windTargetController.enabled = value;

        if(value)
        {
            rb.AddTorque(-50f);
            audioSource.Play();
        }
    }
}
