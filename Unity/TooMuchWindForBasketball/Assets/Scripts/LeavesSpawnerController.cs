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
        IniFrequencyCounter();
    }

    // Update is called once per frame
    void Update()
    {
        // timeFrequency.y == 0f means this Spawner is not enabled
        if(timeFrequency.y != 0f)
        {
            timeFrequencyCounter -= Time.deltaTime;
            
            if(timeFrequencyCounter <= 0f)
            {
                Spawn();
            }
        }
    }

    void Spawn()
    {
        GameObject leafTemplate = leafTemplates[UnityEngine.Random.Range(0, leafTemplates.Length)];
        GameObject leaf = Instantiate(leafTemplate, transform.position, leafTemplate.transform.rotation);

        if(leaf.GetComponent<LeafController>())
        {
            leaf.GetComponent<LeafController>().rb.AddForce(new Vector3(UnityEngine.Random.Range(initialImpulseRange.x, initialImpulseRange.y), 0f, 0f));
        }

        LeavesController.instance.AddLeaf(leaf);
        
        IniFrequencyCounter();
    }

    public void SetFrequency(float ini, float end)
    {
        timeFrequency = new Vector2(ini, end);
        IniFrequencyCounter();
    }

    void IniFrequencyCounter()
    {
        timeFrequencyCounter = Random.Range(timeFrequency.x, timeFrequency.y);
    }
}
