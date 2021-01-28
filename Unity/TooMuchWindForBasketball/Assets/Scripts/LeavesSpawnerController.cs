using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesSpawnerController : MonoBehaviour
{
    [SerializeField] GameObject[] leafTemplates;

    [SerializeField] Vector2 timeFrequency;
    float timeFrequencyCounter;
    [SerializeField] Vector2 initialImpulseRange;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeFrequencyCounter -= Time.deltaTime;

        if(timeFrequencyCounter <= 0f)
        {
            Spawn();
            timeFrequencyCounter = Random.Range(timeFrequency.x, timeFrequency.y);
        }
    }

    void Spawn()
    {
        GameObject leafTemplate = leafTemplates[UnityEngine.Random.Range(0, leafTemplates.Length)];
        GameObject leaf = Instantiate(leafTemplate, transform.position, Quaternion.identity);

        if(leaf.GetComponent<LeaveController>())
        {
            leaf.GetComponent<LeaveController>().rb.AddForce(new Vector3(UnityEngine.Random.Range(initialImpulseRange.x, initialImpulseRange.y), 0f, 0f));
        }

        LeavesController.instance.AddLeaf(leaf);
    }
}
