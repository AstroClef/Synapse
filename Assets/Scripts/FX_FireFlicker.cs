using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX_FireFlicker : MonoBehaviour
{

    private Light lightToFlicker;
    private float maxFlickerRate = 0.15f;
    private float maxIntensity;
    private float minIntensity;
    private float maxRange;

    // Start is called before the first frame update
    void Start()
    {
        lightToFlicker = gameObject.GetComponent<Light>();
        maxIntensity = lightToFlicker.intensity;
        minIntensity = maxIntensity * 0.75f;
        maxRange = lightToFlicker.range;
        StartCoroutine(FlikcerTheLight());
    }

    IEnumerator FlikcerTheLight()
    {
        float timer = Random.Range(0.1f, maxFlickerRate);
        //lightToFlicker.intensity = Random.Range(minIntensity, maxIntensity);
        lightToFlicker.range = Mathf.Lerp(lightToFlicker.range, Random.Range((maxRange * 0.60f), maxRange), 20);
        yield return new WaitForSeconds(timer);
        StartCoroutine(FlikcerTheLight());
    }
}
