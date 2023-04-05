using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleScript : MonoBehaviour {

    GameObject player;

    public GameObject respawn1;
    public GameObject respawn2;
    public GameObject respawn3;
    public GameObject respawn4;
    public Transform playerRespawn;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Primary");
        float x = this.transform.position.x;
        float y = this.transform.position.y;
        float z = this.transform.position.z;

        respawn1 = new GameObject();
        respawn2 = new GameObject();
        respawn3 = new GameObject();
        respawn4 = new GameObject();

        respawn1.transform.position = new Vector3(x + 1, y + 2, z);
        respawn2.transform.position = new Vector3(x - 1, y + 2, z);
        respawn3.transform.position = new Vector3(x, y + 2, z + 1);
        respawn4.transform.position = new Vector3(x, y + 2, z - 1);
    }
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position == respawn1.transform.position)
            playerRespawn = respawn1.transform;
        if (player.transform.position == respawn2.transform.position)
            playerRespawn = respawn2.transform;
        if (player.transform.position == respawn3.transform.position)
            playerRespawn = respawn3.transform;
        if (player.transform.position == respawn4.transform.position)
            playerRespawn = respawn4.transform;


        if (player.transform.position == this.transform.position)
            player.transform.position = playerRespawn.position;
    }
}
