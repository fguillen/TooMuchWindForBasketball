using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesController : MonoBehaviour
{
    List<GameObject> leaves;

    public static LeavesController instance;

    void Awake()
    {
        instance = this;
        leaves = new List<GameObject>();
    }

    public void AddLeaf(GameObject leaf)
    {
        leaves.Add(leaf);
    }

    public void RemoveLeaf(GameObject leaf)
    {
        leaves.Remove(leaf);
    }
    public List<GameObject> AllLeaves()
    {
        return leaves;
    }
}
