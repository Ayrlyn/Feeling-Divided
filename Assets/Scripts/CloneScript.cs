using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneScript : MonoBehaviour {

    GameObject primary;

	// Use this for initialization
	void Start () {
        this.transform.parent = GameObject.Find("Player").transform;
        primary = GameObject.Find("Primary");
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position == primary.transform.position)
        {
            primary.GetComponent<PlayerAbilities>().currentClones--;
            Destroy(this.gameObject);
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            primary.GetComponent<PlayerAbilities>().currentClones--;
            Destroy(this.gameObject);
        }

        if(this.transform.position.y < -1)
        {
            primary.GetComponent<PlayerAbilities>().currentClones--;
            Destroy(this.gameObject);
        }
	}
}
