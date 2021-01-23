using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    public static WindController instance;
    [SerializeField] public float rotationDegrees;
    [SerializeField] public float force;
    [SerializeField] Transform arrow;

    [SerializeField] float noiseRotation;
    [SerializeField] float noiseForce;
    [SerializeField] Vector2 forceLimit;

    [SerializeField] Vector2 arrowOriginalSize;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        arrowOriginalSize = arrow.GetComponent<SpriteRenderer>().size;
        rotationDegrees = arrow.transform.localRotation.eulerAngles.z;
        force = ((forceLimit.y - forceLimit.x) / 2) + forceLimit.x; // in the middle of the limits
    }

    // Update is called once per frame
    void Update()
    {
        ChangeRotate();
        ChangeForce();
        RenderArrow();
    }

    void ChangeRotate()
    {
        rotationDegrees = rotationDegrees + UnityEngine.Random.Range(-noiseRotation, noiseRotation);
        rotationDegrees = rotationDegrees + UnityEngine.Random.Range(-noiseRotation, noiseForce);
    }

    void ChangeForce(){
        force = force + UnityEngine.Random.Range(-noiseForce, noiseForce);

        if(force < forceLimit.x)
            force = forceLimit.x;

        if(force > forceLimit.y)
            force = forceLimit.y;
    }

    void RenderArrow()
    {
        arrow.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, rotationDegrees));
        arrow.GetComponent<SpriteRenderer>().size = arrowOriginalSize * force / 10;
    }
}
