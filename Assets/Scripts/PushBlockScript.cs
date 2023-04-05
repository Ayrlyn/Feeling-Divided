using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBlockScript : MonoBehaviour {

    [SerializeField]
    Transform cameraRotator = null;

    public int size;
    public int playersRequired = 1;
    public int playerCount = 0;
    public List<GameObject> children;

    public bool moveNorth;
    public bool moveSouth;
    public bool moveEast;
    public bool moveWest;

    // Use this for initialization
    void Start () {
        children = new List<GameObject>();
        foreach (Transform child in transform)
        {
            children.Add(child.gameObject);
        }
        size = children.Count;
	}
	
	// Update is called once per frame
	void Update () {
        CheckNorthFaces();
        CheckSouthFaces();
        CheckEastFaces();
        CheckWestFaces();

        bool playerMoving = false;
        GameObject[] Players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject g in Players)
        {
            if (g.GetComponent<PlayerMovement>().moving)
                playerMoving = true;
        }
        playerMoving = false;
        if (!playerMoving)
        {
            if (moveNorth && Input.GetKeyDown(KeyCode.W))
            {
                foreach (GameObject g in children)
                {
                    g.GetComponent<BlockCollisionScript>().MoveNorth();
                }
            }

            else if (moveSouth && Input.GetKeyDown(KeyCode.S))
            {
                foreach (GameObject g in children)
                {
                    g.GetComponent<BlockCollisionScript>().MoveSouth();
                }
            }

            else if (moveEast && Input.GetKeyDown(KeyCode.D))
            {
                foreach (GameObject g in children)
                {
                    g.GetComponent<BlockCollisionScript>().MoveEast();
                }
            }

            else if (moveWest && Input.GetKeyDown(KeyCode.A))
            {
                foreach (GameObject g in children)
                {
                    g.GetComponent<BlockCollisionScript>().MoveWest();
                }
            }
        }
    }

    void CheckNorthFaces()
    {
        moveSouth = false;
        playerCount = 0;
        foreach (GameObject g in children)
        {
            if (g.GetComponent<BlockCollisionScript>().playerNorth)
            {
                playerCount++;
            }
        }
        if (playerCount >= playersRequired)
        {
            moveSouth = true;
        }
        foreach (GameObject g in children)
        {
            if (g.GetComponent<BlockCollisionScript>().wallSouth || g.GetComponent<BlockCollisionScript>().playerSouth)
            {
                moveSouth = false;
            }
        }
    }

    void CheckSouthFaces()
    {
        moveNorth = false;
        playerCount = 0;
        foreach (GameObject g in children)
        {
            if (g.GetComponent<BlockCollisionScript>().playerSouth)
            {
                playerCount++;
            }
        }
        if (playerCount >= playersRequired)
        {
            moveNorth = true;
        }
        foreach (GameObject g in children)
        {
            if (g.GetComponent<BlockCollisionScript>().wallNorth || g.GetComponent<BlockCollisionScript>().playerNorth)
            {
                moveNorth = false;
            }
        }
    }

    void CheckEastFaces()
    {
        moveWest = false;
        playerCount = 0;
        foreach (GameObject g in children)
        {
            if (g.GetComponent<BlockCollisionScript>().playerEast)
            {
                playerCount++;
            }
        }
        if (playerCount >= playersRequired)
        {
            moveWest = true;
        }
        foreach (GameObject g in children)
        {
            if (g.GetComponent<BlockCollisionScript>().wallWest || g.GetComponent<BlockCollisionScript>().wallWest)
            {
                moveWest = false;
            }
        }
    }

    void CheckWestFaces()
    {
        moveEast = false;
        playerCount = 0;
        foreach (GameObject g in children)
        {
            if (g.GetComponent<BlockCollisionScript>().playerWest)
            {
                playerCount++;
            }
        }
        if (playerCount >= playersRequired)
        {
            moveEast = true;
        }
        foreach (GameObject g in children)
        {
            if (g.GetComponent<BlockCollisionScript>().wallEast || g.GetComponent<BlockCollisionScript>().playerEast)
            {
                moveEast = false;
            }
        }
    }
}
