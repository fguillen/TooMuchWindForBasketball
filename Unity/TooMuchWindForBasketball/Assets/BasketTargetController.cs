﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketTargetController : MonoBehaviour
{
    [SerializeField] ParticleSystem basketEffect;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Ball"))
        {   
            // Only if the ball is falling down
            if(other.GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                PlayerController.instance.IncreasePoints();
                ShowBasketEffect();
            }
        }
    }

    void ShowBasketEffect()
    {
        Instantiate(basketEffect, transform.position, Quaternion.identity);
        BasketNetController.instance.Move();
        audioSource.Play();
    }
}
