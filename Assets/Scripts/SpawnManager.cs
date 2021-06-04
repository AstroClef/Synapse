using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameManager gameManager;
    public List<GameObject> spawnLibrary;

    [SerializeField] private float spawnRange;
    [SerializeField] private float spawnCount = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        spawnRange = gameManager.GetWorldBound() * 0.98f;
        spawnCount = FindObjectsOfType<SynapSample>().Length;
        if (spawnCount == 0) { gameManager.NextWave(); SpawnWave((gameManager.GetCurrentWave() - 1) * 5); }
    }

    void SpawnWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            SpawnSynapsSamples();
        }
    }

    void SpawnSynapsSamples()
    {
        int spawnID = Random.Range(0, spawnLibrary.Count);
        Instantiate(spawnLibrary[spawnID], GenerateSpawnPoint(), Quaternion.Euler(0, Random.Range(0f, 360f), 0));
    }

    Vector3 GenerateSpawnPoint()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPoint = new Vector3(spawnX, 0, spawnZ);
        //Debug.Log("Spawn Point: " + spawnPoint);

        return spawnPoint;
    }
}
