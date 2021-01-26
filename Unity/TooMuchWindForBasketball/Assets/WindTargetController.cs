using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTargetController : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveByTheWind();
    }


    public void MoveByTheWind()
    {
        Quaternion windDirection = Quaternion.Euler(0f, 0f, WindController.instance.angle);
        float windForce = WindController.instance.force;

        rb.AddForce(windDirection * new Vector3(0f, 1f, 0f) * windForce);
    }
}
