using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesOnTheCameraController : MonoBehaviour
{
    [SerializeField] public Transform cameraPointLimitNW;
    [SerializeField] public Transform cameraPointLimitSE;

    public static LeavesOnTheCameraController instance;

    void Awake()
    {
        instance = this;
    }

    // void SendOneRandomLeafToCamera()
    // {
    //     List<GameObject> leaves = LeavesSeenByCamera();
    //     GameObject leaf = leaves[Random.Range(0, leaves.Count)];

        
    // }


    // List<GameObject> LeavesSeenByCamera()
    // {
    //     Camera camera = Camera.main;
    //     List<GameObject> leaves = new List<GameObject>();

    //     foreach (GameObject leaf in LeavesController.instance.AllLeaves())
    //     {
    //         if(IsTargetVisible(camera, leaf))
    //             leaves.Add(leaf);
    //     }

    //     return leaves;
    // }


    // bool IsTargetVisible(Camera camera, GameObject gameObject)
    // {
    //    var planes = GeometryUtility.CalculateFrustumPlanes(camera);
    //    var point = gameObject.transform.position;
    //    foreach (var plane in planes)
    //    {
    //        if (plane.GetDistanceToPoint(point) < 0)
    //           return false;
    //    }
    //    return true;
    // }
}

