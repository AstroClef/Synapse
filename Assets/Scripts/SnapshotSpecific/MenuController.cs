using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    ChangeScenes changeScenes;
    public string m_Scene;

    
    // Start is called before the first frame update
    void Start()
    {
        changeScenes = GetComponent<ChangeScenes>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            StartCoroutine(changeScenes.LoadScene(m_Scene));
        }
    }
}
