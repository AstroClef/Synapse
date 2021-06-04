using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAfterGivenWave : MonoBehaviour
{

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GetCurrentWave() > 1)
        {
            Destroy(gameObject);
        }
    }
}
