using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    AI_Wander wanderScript;
    SynapSample synapSample;
    Animator objectAnimator;

    // Start is called before the first frame update
    void Start()
    {
        wanderScript = GetComponent<AI_Wander>();
        synapSample = GetComponent<SynapSample>();
    }

    // Update is called once per frame
    void Update()
    {
        if(objectAnimator == null)
        {
            objectAnimator = synapSample.GetCurrentSkin().GetComponent<Animator>();
        }

        float distance = Vector3.Distance(wanderScript.target, transform.position);

        if (distance> 2f && synapSample.isOnGround && wanderScript.GetFirstWalk())
        {
            objectAnimator.SetBool("Locomotion_b", true);
        } else if (distance <= 2f || !synapSample.isOnGround )
        {
            objectAnimator.SetBool("Locomotion_b", false);
        }
    }
}
