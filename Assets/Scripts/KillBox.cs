using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{

    [SerializeField] private ParticleSystem blood;
    private int killCount = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SynapsSample"))
        {
            Destroy(other.gameObject);
            blood.Play();
            killCount++;
        }
    }

    public int GetKillCount()
    {
        return killCount;
    }
}
