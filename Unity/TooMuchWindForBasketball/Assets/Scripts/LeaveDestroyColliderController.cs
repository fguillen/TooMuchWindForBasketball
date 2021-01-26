using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveDestroyColliderController : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other)
    {        
        if(other.gameObject.CompareTag("Leaf"))
        {
            LeavesController.instance.AddLeaf(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
