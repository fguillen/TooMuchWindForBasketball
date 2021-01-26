using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    public static WindController instance;
    [SerializeField] float angle;
    [SerializeField] float force;
    [SerializeField] float smallAngleNoise;
    [SerializeField] float smallNoiseForce;
    [SerializeField] Vector2 forceLimits;
    [SerializeField] Vector2 angleLimits;

    [SerializeField] float bigChangeSeconds;
    [SerializeField] float bigChangeSecondsNoise;
    float bigAngleChangeSecondsCounter;
    float bigForceChangeSecondsCounter;

    [SerializeField] float flipDirectionSeconds;
    [SerializeField] float flipDirectionSecondsNoise;
    [SerializeField] float flipDirectionSecondsDuration;
    [SerializeField] float flipDirectionSecondsDurationNoise;
    float flipDirectionSecondsCounter;
    float flipDirectionSecondsDurationCounter;

    bool isFlipped;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        IniBigAngleChangeSecondsCounter();
        IniBigForceChangeSecondsCounter();
        IniFlipDirectionSecondsCounter();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeAngleSmall();
        ChangeForceSmall();
        CheckBigChanges();
    }

    void CheckBigChanges()
    {
        // angle
        bigAngleChangeSecondsCounter -= Time.deltaTime;
        if(bigAngleChangeSecondsCounter <= 0)
            ChangeAngleBig();
        
        // force
        bigForceChangeSecondsCounter -= Time.deltaTime;
        if(bigForceChangeSecondsCounter <= 0)
            ChangeForceBig();

        if(isFlipped)
        {
            flipDirectionSecondsDurationCounter -= Time.deltaTime;
            if(flipDirectionSecondsDurationCounter <= 0)
                UnflipDirection();
        } else 
        {
            flipDirectionSecondsCounter -= Time.deltaTime;
            if(flipDirectionSecondsCounter <= 0)
                FlipDirection();
        }
        
    }

    // angle :: INI
    void IniBigAngleChangeSecondsCounter()
    {
        bigAngleChangeSecondsCounter = bigChangeSeconds + Random.Range(-bigChangeSecondsNoise, bigChangeSecondsNoise);
    }
    void ChangeAngleBig()
    {
        angle = Random.Range(angleLimits.x, angleLimits.y);
        IniBigAngleChangeSecondsCounter();
    }
    void ChangeAngleSmall()
    {
        angle = angle + UnityEngine.Random.Range(-smallAngleNoise, smallAngleNoise);

        if(angle < angleLimits.x)
            angle = angleLimits.x;

        if(angle > angleLimits.y)
            angle = angleLimits.y;
    }
    // angle :: END

    // force :: INI
    void IniBigForceChangeSecondsCounter()
    {
        bigForceChangeSecondsCounter = bigChangeSeconds + Random.Range(-bigChangeSecondsNoise, bigChangeSecondsNoise);
    }

    void ChangeForceBig()
    {
        force = Random.Range(forceLimits.x, forceLimits.y);
        IniBigForceChangeSecondsCounter();
    }

    void ChangeForceSmall(){
        force = force + UnityEngine.Random.Range(-smallNoiseForce, smallNoiseForce);

        if(force < forceLimits.x)
            force = forceLimits.x;

        if(force > forceLimits.y)
            force = forceLimits.y;
    }
    // force :: END

    // flip
    void IniFlipDirectionSecondsCounter()
    {
        flipDirectionSecondsCounter = flipDirectionSeconds + Random.Range(-flipDirectionSecondsNoise, flipDirectionSecondsNoise);
    }

    void IniFlipDirectionSecondsDurationCounter()
    {
        flipDirectionSecondsDurationCounter = flipDirectionSecondsDuration + Random.Range(-flipDirectionSecondsDurationNoise, flipDirectionSecondsDurationNoise);
    }

    void FlipDirection()
    {
        isFlipped = true;
        IniFlipDirectionSecondsDurationCounter();
    }

    void UnflipDirection()
    {
        isFlipped = false;
        IniFlipDirectionSecondsCounter();
    }
    //

    public float GetAngle()
    {
        if(isFlipped)
        {
            return -angle;
        } else 
        {
            return angle;
        }
    }

    public float GetForce()
    {
        return force;
    }

}
