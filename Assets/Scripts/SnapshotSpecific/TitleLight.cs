using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleLight : MonoBehaviour
{

    [SerializeField] private float speed;
    private float minX;
    private float maxX;

    // Start is called before the first frame update
    void Start()
    {
        minX = transform.position.x;
        maxX = minX + 5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, maxX - minX) + minX, transform.position.y, transform.position.z);
    }
}
