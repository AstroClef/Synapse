using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAICowsOnce : MonoBehaviour
{
    public GameManager gameManager;
    public List<GameObject> spawnLibrary;

    [SerializeField] private float spawnRange;

    // Start is called before the first frame update
    void Start()
    {
        SpawnReset();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager == null) { SpawnReset(); }
    }

    void SpawnWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            SpawnSynapsSamples();
        }
    }

    private void SpawnReset()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        spawnRange = gameManager.GetWorldBound() * 0.98f;
        SpawnWave(15);
    }
    
    void SpawnSynapsSamples()
    {
        int spawnID = Random.Range(0, spawnLibrary.Count);
        Instantiate(spawnLibrary[spawnID], GenerateSpawnPoint(), spawnLibrary[spawnID].transform.rotation);
    }

    Vector3 GenerateSpawnPoint()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPoint = new Vector3(spawnX, 0, spawnZ);

        return spawnPoint;
    }
}
