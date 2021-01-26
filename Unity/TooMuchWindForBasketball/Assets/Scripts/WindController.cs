using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    public static WindController instance;
    [SerializeField] public float angle;
    [SerializeField] public float force;
    [SerializeField] float smallAngleNoise;
    [SerializeField] float smallNoiseForce;
    [SerializeField] Vector2 forceLimits;
    [SerializeField] Vector2 angleLimits;

    [SerializeField] float bigChangeSeconds;
    [SerializeField] float bigChangeSecondsNoise;
    float bigAngleChangeSecondsCounter;
    float bigForceChangeSecondsCounter;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        IniBigAngleChangeSecondsCounter();
        IniBigForceChangeSecondsCounter();
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
    }

    void IniBigAngleChangeSecondsCounter()
    {
        bigAngleChangeSecondsCounter = bigChangeSeconds + Random.Range(-bigChangeSecondsNoise, bigChangeSecondsNoise);
    }

    void ChangeAngleBig()
    {
        angle = Random.Range(angleLimits.x, angleLimits.y);
        IniBigAngleChangeSecondsCounter();
    }

    void IniBigForceChangeSecondsCounter()
    {
        bigForceChangeSecondsCounter = bigChangeSeconds + Random.Range(-bigChangeSecondsNoise, bigChangeSecondsNoise);
    }

    void ChangeForceBig()
    {
        force = Random.Range(forceLimits.x, forceLimits.y);
        IniBigForceChangeSecondsCounter();
    }


    void ChangeAngleSmall()
    {
        angle = angle + UnityEngine.Random.Range(-smallAngleNoise, smallAngleNoise);

        if(angle < angleLimits.x)
            angle = angleLimits.x;

        if(angle > angleLimits.y)
            angle = angleLimits.y;
    }

    void ChangeForceSmall(){
        force = force + UnityEngine.Random.Range(-smallNoiseForce, smallNoiseForce);

        if(force < forceLimits.x)
            force = forceLimits.x;

        if(force > forceLimits.y)
            force = forceLimits.y;
    }
}
