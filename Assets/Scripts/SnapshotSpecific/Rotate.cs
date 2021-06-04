using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private Vector3 rotationAngle;
    [SerializeField] private float speed;
    [SerializeField] private bool isBouncing;

    private float bounceMin;
    private float bounceMax;

    // Start is called before the first frame update
    void Start()
    {
        bounceMin = transform.position.y;
        bounceMax = bounceMin + 0.33f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationAngle * Time.deltaTime * speed);

        if (isBouncing)
        {
            transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time/4, bounceMax - bounceMin) + bounceMin);
        }

    }
}
