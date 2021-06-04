using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIFlicker : MonoBehaviour
{
    private TextMeshPro text;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        text.color = new Color(text.color.r, text.color.b, text.color.g, Mathf.PingPong(Time.time * speed, 1f)+ 0.25f);
    }
}
