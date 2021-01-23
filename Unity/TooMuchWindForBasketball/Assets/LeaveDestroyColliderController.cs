using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveDestroyColliderController : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other)
    {
        print("Collising with LeaveDestroyCollider: " + other.gameObject.tag);
        
        if(other.gameObject.CompareTag("Leave"))
        {
            Destroy(other.gameObject);
        }
    }
}
