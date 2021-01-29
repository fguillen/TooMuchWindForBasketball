using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesDestroyColliderController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {        
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
}
