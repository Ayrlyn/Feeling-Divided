using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollisionScript : MonoBehaviour
{
    [SerializeField]
    PlayerMovement playerMovement = null;

    float moveSpeed;

    Vector3 targetPosition;
    Vector3 startPosition;
    bool moving;

    float rayLength = 1.4f;
    public bool playerNorth;
    public bool playerSouth;
    public bool playerEast;
    public bool playerWest;

    public bool wallNorth;
    public bool wallSouth;
    public bool wallEast;
    public bool wallWest;

    [SerializeField]
    Transform cameraRotator = null;

    // Use this for initialization
    void Start ()
    {
        moveSpeed = playerMovement.moveSpeed;
        playerNorth = playerSouth = playerEast = playerWest = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.E))
        {
            playerNorth = false;
            playerSouth = false;
            playerEast = false;
            playerWest = false;

            wallNorth = false;
            wallSouth = false;
            wallEast = false;
            wallWest = false;
        }
        CheckSurroundings();

        if (moving)
        {
            if (Vector3.Distance(startPosition, transform.position) > 1f)
            {
                float x = Mathf.Round(targetPosition.x);
                float y = Mathf.Round(targetPosition.y);
                float z = Mathf.Round(targetPosition.z);

                transform.position = new Vector3(x, y, z);

                moving = false;
                return;
            }

            transform.position += (targetPosition - startPosition) * moveSpeed * Time.deltaTime;
            return;
        }
    }

    void CheckSurroundings()
    {
        RaycastHit hit;
        //North
        if (Physics.Raycast(transform.position, cameraRotator.transform.forward, out hit, rayLength))
        {
            if (hit.transform.gameObject.tag == "Player")
                playerNorth = true;
            if (hit.transform.gameObject.tag == "Wall")
                wallNorth = true;
        }
        else
        {
            playerNorth = false;
            wallNorth = false;
        }
        //South
        if (Physics.Raycast(transform.position, -cameraRotator.transform.forward, out hit, rayLength))
        {
            if (hit.transform.gameObject.tag == "Player")
                playerSouth = true;
            if (hit.transform.gameObject.tag == "Wall")
                wallSouth = true;
        }
        else
        {
            playerSouth = false;
            wallSouth = false;
        }
        //East
        if (Physics.Raycast(transform.position, cameraRotator.transform.right, out hit, rayLength))
        {
            if (hit.transform.gameObject.tag == "Player")
                playerEast = true;
            if (hit.transform.gameObject.tag == "Wall")
                wallEast = true;
        }
        else
        {
            playerEast = false;
            wallEast = false;
        }
        //West
        if (Physics.Raycast(transform.position, -cameraRotator.transform.right, out hit, rayLength))
        {
            if (hit.transform.gameObject.tag == "Player")
                playerWest = true;
            if (hit.transform.gameObject.tag == "Wall")
                wallWest = true;
        }
        else
        {
            playerWest = false;
            wallWest = false;
        }
    }

    public void MoveNorth()
    {
        targetPosition = transform.position + cameraRotator.transform.forward;
        startPosition = transform.position;
        moving = true;

        PlayerMovement playerCube;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -cameraRotator.transform.forward, out hit, rayLength))
        {
            if (hit.transform.gameObject.tag == "Player")
            {
                playerCube = hit.transform.gameObject.GetComponent<PlayerMovement>();
                playerCube.targetPosition = this.transform.position;
                playerCube.startPosition = this.transform.position - cameraRotator.transform.forward;
                playerCube.moving = true;
            }
        }
    }

    public void MoveSouth()
    {
        targetPosition = transform.position - cameraRotator.transform.forward;
        startPosition = transform.position;
        moving = true;

        PlayerMovement playerCube;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, cameraRotator.transform.forward, out hit, rayLength))
        {
            if (hit.transform.gameObject.tag == "Player")
            {
                playerCube = hit.transform.gameObject.GetComponent<PlayerMovement>();
                playerCube.targetPosition = this.transform.position;
                playerCube.startPosition = this.transform.position + cameraRotator.transform.forward;
                playerCube.moving = true;
            }
        }
    }

    public void MoveEast()
    {
        targetPosition = transform.position + cameraRotator.transform.right;
        startPosition = transform.position;
        moving = true;

        PlayerMovement playerCube;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -cameraRotator.transform.right, out hit, rayLength))
        {
            if (hit.transform.gameObject.tag == "Player")
            {
                playerCube = hit.transform.gameObject.GetComponent<PlayerMovement>();
                playerCube.targetPosition = this.transform.position;
                playerCube.startPosition = this.transform.position - cameraRotator.transform.right;
                playerCube.moving = true;
            }
        }

    }

    public void MoveWest()
    {
        targetPosition = transform.position - cameraRotator.transform.right;
        startPosition = transform.position;
        moving = true;

        PlayerMovement playerCube;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, cameraRotator.transform.right, out hit, rayLength))
        {
            if (hit.transform.gameObject.tag == "Player")
            {
                playerCube = hit.transform.gameObject.GetComponent<PlayerMovement>();
                playerCube.targetPosition = this.transform.position;
                playerCube.startPosition = this.transform.position + cameraRotator.transform.right;
                playerCube.moving = true;
            }
        }
    }
}
