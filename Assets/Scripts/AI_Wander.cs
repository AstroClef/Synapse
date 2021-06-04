using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Wander : MonoBehaviour
{
    GameManager gameManager;
    SynapSample synapSample;
    
    public float wanderRadius;
    public float wanderTimer;

    public Vector3 target;
    private NavMeshAgent agent;
    private float timer = 0f;

    private bool firstWalk = false;

    // Use this for initialization
    void OnEnable()
    {
        gameManager = FindObjectOfType<GameManager>();
        synapSample = GetComponent<SynapSample>();

        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        timer = Random.Range(0, wanderTimer);
        timer += Time.deltaTime;

        if (timer >= wanderTimer && synapSample.isOnGround)
        {
            firstWalk = true;
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            target = newPos;
            timer = 0;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    public bool GetFirstWalk()
    {
        return firstWalk;
    }
}
