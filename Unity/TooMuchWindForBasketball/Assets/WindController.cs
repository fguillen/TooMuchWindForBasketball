using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    public static WindController instance;
    [SerializeField] public float angle;
    [SerializeField] public float force;
    [SerializeField] float noiseRotation;
    [SerializeField] float noiseForce;
    [SerializeField] Vector2 forceLimit;

    [SerializeField] Vector2 arrowOriginalSize;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        // ChangeRotate();
        // ChangeForce();
    }

    void ChangeRotate()
    {
        angle = angle + UnityEngine.Random.Range(-noiseRotation, noiseRotation);
        angle = angle + UnityEngine.Random.Range(-noiseRotation, noiseForce);
    }

    void ChangeForce(){
        force = force + UnityEngine.Random.Range(-noiseForce, noiseForce);

        if(force < forceLimit.x)
            force = forceLimit.x;

        if(force > forceLimit.y)
            force = forceLimit.y;
    }
}
