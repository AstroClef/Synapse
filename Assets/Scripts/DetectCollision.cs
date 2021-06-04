using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Object Detected! Is Sample: " + isSample);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("SynapsSample"))
        {
            other.gameObject.GetComponent<SynapSample>().selfInTractor = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("SynapsSample"))
        {
            other.gameObject.GetComponent<SynapSample>().selfInTractor = false;
        }
    }
}
