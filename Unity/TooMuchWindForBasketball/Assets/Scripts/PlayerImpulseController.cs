﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImpulseController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform arrow;
    [SerializeField] SpriteRenderer arrowSprite;
    [SerializeField] float angle;
    [SerializeField] float angleStep;
    [SerializeField] Vector2 angleLimits;
    [SerializeField] float force;
    [SerializeField] float forceStep;
    [SerializeField] Vector2 forceLimits;
    [SerializeField] Vector2 arrowSizeMultiplierLimits;

    Vector2 arrowOriginalSize;

    public static PlayerImpulseController instance;

    void Start()
    {
        force = forceLimits.x;
        angle = angleLimits.x;
        arrowOriginalSize = arrowSprite.size;

        instance = this;

        CheckShowArrow();
    }

    void Update()
    {
        if(PlayerController.instance.hasTheBallCaught)
        {
            CheckShowArrow();
            CheckAngle();
            CheckForce();
            CheckForceReleased();
            RenderArrow();
        }
    }

    void CheckShowArrow()
    {
        if(Input.GetButton("Jump"))
        {
            arrowSprite.enabled = true;
        } else{
            arrowSprite.enabled = false;
        }
    }

    void CheckAngle()
    {
        // Only change angle if we are pushing the button
        if(Input.GetButton("Jump"))
        {
            float vertical = Input.GetAxisRaw("Vertical");

            if(vertical > 0)
                angle -= angleStep * Time.deltaTime;

            if(vertical < 0)
                angle += angleStep * Time.deltaTime;

            if(angle < 0)
                angle = 360 + angle;

            if(angle > 360)
                angle = angle - 360;

            if(angle < angleLimits.x)
                angle = angleLimits.x;

            if(angle > angleLimits.y)
                angle = angleLimits.y;
        }
    }

    void CheckForce()
    {
        if(Input.GetButton("Jump"))
        {
            force += forceStep * Time.deltaTime;

            if(force > forceLimits.y)
            {
                force = forceLimits.y;
                forceStep = -forceStep;
            }

            if(force < forceLimits.x)
            {
                force = forceLimits.x;
                forceStep = -forceStep;
            }
        }
    }

    void CheckForceReleased()
    {
        if(Input.GetButtonUp("Jump"))
        {
            PlayerController.instance.ShootBall(angle, force);
            force = forceLimits.x;
            forceStep = Mathf.Abs(forceStep);
        }
    }

    void RenderArrow()
    {
        arrow.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        var sizeMultiplier = TransformForceToSizeMultiplier(force);
        arrowSprite.size = new Vector2(arrowOriginalSize.x * sizeMultiplier, arrowOriginalSize.y);
    }

    float TransformForceToSizeMultiplier(float force)
    {
        var a = forceLimits.x;
        var b = forceLimits.y;
        var c = arrowSizeMultiplierLimits.x;
        var d = arrowSizeMultiplierLimits.y;
        var e = force;

        var result = c + (((e - a) * (d - c)) / (b - a));

        return result;
    }
}
