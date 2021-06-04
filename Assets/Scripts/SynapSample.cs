using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SynapSample : MonoBehaviour
{
    
    private GameManager gameManager;
    private Rigidbody sampleRB;
    private NavMeshAgent navAgent;
    public bool tractorActive;
    public bool selfInTractor = false;
    public bool rotationReset = true;

    [SerializeField] private List<GameObject> sampleMesh;

    [SerializeField] private GameObject tractorEffect;
    

    private GameObject currentSkin;

    public int pointValue;
    public float speed;

    public bool isOnGround;

    
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        navAgent = GetComponent<NavMeshAgent>();
        sampleRB = GetComponent<Rigidbody>();
        isOnGround = true;
        SetSkin();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = gameManager.CheckWorldBounds(transform.position, false);
        MethodOnTractorEnter();
    }


    public void SetSkin()
    {
        currentSkin = sampleMesh[Random.Range(0, sampleMesh.Count)];
        currentSkin.gameObject.SetActive(true);
    }

    private void MethodOnTractorEnter()
    {
        if(GameObject.Find("TractorBeam") == null)
        {
            selfInTractor = false;

        }
        //Debug.Log(GameObject.Find("TractorBeam") + "" + selfInTractor);
        if (selfInTractor)
        {
            isOnGround = false;
            rotationReset = false;
            sampleRB.useGravity = false;
            sampleRB.isKinematic = true;
            navAgent.enabled = false;
            GetSucked();
            tractorEffect.SetActive(true);
        }
        else if (!selfInTractor && !isOnGround)
        {
            //Debug.Log("HOMIE, SIT DOWN");
            tractorEffect.SetActive(false);
            sampleRB.useGravity = true;
            sampleRB.isKinematic = false;
        }
    }
    
    private void GetSucked()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player").gameObject.transform.position, Time.deltaTime * speed);
    }

    public GameObject GetCurrentSkin()
    {
        return currentSkin;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("Yo! Fam! We Landed!");
            isOnGround = true;
            if (!rotationReset)
            {
                transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
                rotationReset = true;
            }
            if (!selfInTractor)
            {
                Debug.Log("Quit Movin");
                sampleRB.useGravity = false;
                sampleRB.isKinematic = true;
            }
            navAgent.enabled = true;
        }
    }
}

