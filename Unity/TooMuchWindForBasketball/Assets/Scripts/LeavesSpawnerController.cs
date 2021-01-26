using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesSpawnerController : MonoBehaviour
{
    [SerializeField] GameObject[] leafTemplates;

    [SerializeField] float time;
    [SerializeField] float timeCounter;
    [SerializeField] float initialImpulseRange;

    // Start is called before the first frame update
    void Start()
    {
        timeCounter = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;

        if(timeCounter > time)
        {
            Spawn();
            timeCounter = 0f;
        }
    }

    void Spawn()
    {
        GameObject leafTemplate = leafTemplates[UnityEngine.Random.Range(0, leafTemplates.Length)];
        GameObject leaf = Instantiate(leafTemplate, transform.position, Quaternion.identity);

        leaf.GetComponent<LeaveController>().rb.AddForce(new Vector3(UnityEngine.Random.Range(-initialImpulseRange, initialImpulseRange), 0f, 0f));

        LeavesController.instance.AddLeaf(leaf);
    }
}
