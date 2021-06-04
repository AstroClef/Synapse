using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapshot_SynapSample : MonoBehaviour
{
    [SerializeField] private List<GameObject> sampleMesh;
    [SerializeField] private GameObject tractorEffect;

    private GameObject currentSkin;
    // Start is called before the first frame update
    void Start()
    {
        //SetSkin();
        tractorEffect.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSkin()
    {
        currentSkin = sampleMesh[Random.Range(0, sampleMesh.Count)];
        currentSkin.gameObject.SetActive(true);
    }
}
