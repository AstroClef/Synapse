using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    ChangeScenes changeScenes;

    [SerializeField] private TextMeshPro samplesRemainingDisplay;
    [SerializeField] private TextMeshPro timeDisplay;
    [SerializeField] private GameObject killBox;
    [SerializeField] private GameObject timeDisplayUI;
    public const float BOUND_WORLDEDGE = 19.5f;
    public const float BOUND_SKYFLOOR = 3f;
    public const float BOUND_CEILEING = 10f;
    public const float BOUND_GROUND = 0f;

    private int currentWave = 1;
    private int samplesRemaining;

    private bool inGameLoop = true;
    private bool startSceneLoad = false;

    [SerializeField] private bool isGameplayScene = false;
    private float currentTime;
    private float waveTime = 61;

    // Start is called before the first frame update
    void Start()
    {
        changeScenes = GetComponent<ChangeScenes>();
        currentTime = waveTime;
        UIElementUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        UIElementUpdate();
        if (isGameplayScene)
        {
            GameLoop();
        }
    }

    public void GameLoop()
    {
        samplesRemaining = FindObjectsOfType<SynapSample>().Length;
        if (inGameLoop && currentWave > 1)
        {
            currentTime -= Time.deltaTime;
            Debug.Log(currentTime);
            if(currentTime <= 0f)
            {
                currentTime = 0f;
                inGameLoop = false;
                startSceneLoad = true;
            }
        }
        if (startSceneLoad)
        {
            startSceneLoad = false;
            StartCoroutine(changeScenes.LoadScene("EndScreen"));
        }
    }

    public void UIElementUpdate()
    {
        if (currentWave > 1)
        {
            timeDisplayUI.SetActive(true);
        }
        else
        {
            timeDisplayUI.SetActive(false);
        }
        samplesRemainingDisplay.text = "" + samplesRemaining;
        timeDisplay.text = "" + (int)currentTime;
    }

    public Vector3 CheckWorldBounds(Vector3 objectPosition, bool isUFO)
    {

        Vector3 newPosition = objectPosition;

        //Floor and Ceiling Checks
        if (newPosition.y > BOUND_CEILEING && isUFO)
        {
            Debug.Log("Too HIGH!!!");
            newPosition = new Vector3(newPosition.x, BOUND_CEILEING, newPosition.z);
        }
        else if (newPosition.y < BOUND_SKYFLOOR && isUFO)
        {
            Debug.Log("Too LOW!!!");
            newPosition = new Vector3(newPosition.x, BOUND_SKYFLOOR, newPosition.z);
        }else if(newPosition.y < BOUND_GROUND && !isUFO)
        {
            newPosition = new Vector3(newPosition.x, BOUND_GROUND, newPosition.z);
        }

        //X Bound Check
        if (newPosition.x > BOUND_WORLDEDGE)
        {
            newPosition = new Vector3(BOUND_WORLDEDGE, newPosition.y, newPosition.z);
        }
        else if (newPosition.x < -BOUND_WORLDEDGE)
        {
            newPosition = new Vector3(-BOUND_WORLDEDGE, newPosition.y, newPosition.z);
        }

        //Z Bound Check
        if (newPosition.z > BOUND_WORLDEDGE)
        {
            newPosition = new Vector3(newPosition.x, newPosition.y, BOUND_WORLDEDGE);
        }
        else if (newPosition.z < -BOUND_WORLDEDGE)
        {
            newPosition = new Vector3(newPosition.x, newPosition.y, -BOUND_WORLDEDGE);
        }

        return newPosition;
    }

    public float GetWorldBound()
    {
        return BOUND_WORLDEDGE;
    }

    public int GetCurrentWave()
    {
        return currentWave;
    }

    public void NextWave()
    {
        currentWave++;
        currentTime = waveTime;
    }
}
