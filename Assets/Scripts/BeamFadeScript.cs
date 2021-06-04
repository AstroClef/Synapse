using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamFadeScript : MonoBehaviour
{

    [SerializeField] Material tractorBeamMaterial;

    [SerializeField] private float speed;
    private float maxOpacity;

    // Start is called before the first frame update
    void Start()
    {
        //tractorBeamMaterial = GetComponent<Material>();
        maxOpacity = 0.2f;
        Debug.Log("Opacity" + maxOpacity);
    }

    // Update is called once per frame
    void Update()
    {
        tractorBeamMaterial.color = new Color(tractorBeamMaterial.color.r, tractorBeamMaterial.color.g, tractorBeamMaterial.color.b, Mathf.PingPong(Time.time * speed, maxOpacity));
    }
}
