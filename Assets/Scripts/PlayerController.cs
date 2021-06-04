using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    GameManager gameManager;
    [SerializeField] public GameObject tractorBeam;

    [SerializeField] float startSpeed = 10f;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = startSpeed;
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovementUpdate();
        MiscInputUpdate();
        transform.position = gameManager.CheckWorldBounds(transform.position, true);
        //CheckBounds();
    }

    private void MovementUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float heightInput = 0f;

        //Checks Location Against World Bounds
        

        //Checks if Y-Axis Movement Controls (Left Shift & Left Control) are being pressed.
        if (Input.GetKey(KeyCode.LeftShift)) { heightInput = 1f; Debug.Log("Rising"); } else if (Input.GetKey(KeyCode.LeftControl)) { heightInput = -1f; Debug.Log("Lowering"); } else { heightInput = 0f; }

        Vector3 moveDirection = new Vector3(horizontalInput, heightInput, verticalInput);
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    private void MiscInputUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            tractorBeam.SetActive(true);
            GameObject.Find("Main Camera").GetComponent<Camera_FollowPlayer>().fireIsClicked = true;
            speed = startSpeed * 0.5f;
        }
        else
        {
            tractorBeam.SetActive(false);
            GameObject.Find("Main Camera").GetComponent<Camera_FollowPlayer>().fireIsClicked = false;
            speed = startSpeed;
        }
    }
    
}
