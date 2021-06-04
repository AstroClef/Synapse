using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_FollowPlayer : MonoBehaviour
{

    [SerializeField] GameObject player;
    private Vector3 playerPos;
    [SerializeField] Vector3 baseFollowDistance;
    [SerializeField] Vector3 tractorFollowDistance;
    [SerializeField] float speed;

    public bool fireIsClicked = false;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        playerPos = player.transform.position;
        
        //Moves Tractor Beam into better view when it is Active.
        if (fireIsClicked)
        {
            if (transform.position != playerPos + tractorFollowDistance)
            {
                transform.position = Vector3.Lerp(transform.position, playerPos + tractorFollowDistance, Time.deltaTime * speed);
            }
            else
            {
                transform.position = playerPos + tractorFollowDistance;
            }
        }
        else
        {
            if (transform.position != playerPos + baseFollowDistance)
            {
                transform.position = Vector3.Lerp(transform.position, playerPos + baseFollowDistance, Time.deltaTime * speed);
            }
            else
            {
                transform.position = playerPos + baseFollowDistance;
            }
        }
    }
}
