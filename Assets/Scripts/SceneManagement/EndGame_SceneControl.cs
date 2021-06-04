using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame_SceneControl : MonoBehaviour
{

    [SerializeField] private float waitTime;
    private ChangeScenes changeScenes;
    private bool startLoadScene = false;
    private bool hasWaited = false;
    
    // Start is called before the first frame update
    void Start()
    {
        changeScenes = GetComponent<ChangeScenes>();
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        Debug.Log(waitTime);
        if(waitTime <= 0 && !hasWaited)
        {
            startLoadScene = !startLoadScene;
        }
        if (startLoadScene)
        {
            hasWaited = !hasWaited;
            startLoadScene = !startLoadScene;
            StartCoroutine(changeScenes.LoadScene("Snapshot"));
        }
    }
}
