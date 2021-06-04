using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorLight : MonoBehaviour
{

    private Light tractorLight;
    [SerializeField] private float flickerRate;
    [SerializeField] private float flickerIntensity;

    // Start is called before the first frame update
    void Start()
    {
        tractorLight = gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        tractorLight.intensity = Mathf.PingPong(Time.time * flickerRate, flickerIntensity - (flickerIntensity/2))+(flickerIntensity/2);
        if(transform.position.y != 0.1f)
        {
            transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
        }
    }
}
