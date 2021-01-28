using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveDestroyColliderController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {        
        print("LeaveDestroyColliderController tag: " + other.gameObject.tag);

        if(other.gameObject.CompareTag("Leaf"))
        {
            LeavesController.instance.AddLeaf(other.gameObject);
            Destroy(other.gameObject);
        }

        if(
            other.gameObject.CompareTag("Building") ||
            other.gameObject.CompareTag("Player") ||
            other.gameObject.CompareTag("WindIndicator") ||
            other.gameObject.CompareTag("Basket") ||
            other.gameObject.CompareTag("Ball")
        )
        {
            Destroy(other.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {        
        print("LeaveDestroyColliderController Trigger tag: " + other.gameObject.tag);
    }
}
