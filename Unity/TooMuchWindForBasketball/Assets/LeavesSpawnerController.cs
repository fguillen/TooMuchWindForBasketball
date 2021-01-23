using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesSpawnerController : MonoBehaviour
{
    [SerializeField] GameObject[] leaveTemplates;

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
        GameObject leaveTemplate = leaveTemplates[UnityEngine.Random.Range(0, leaveTemplates.Length)];
        GameObject leave = Instantiate(leaveTemplate, transform.position, Quaternion.identity);

        leave.GetComponent<LeaveController>().rb.AddForce(new Vector3(0f, UnityEngine.Random.Range(-initialImpulseRange, initialImpulseRange), 0f));
    }
}
