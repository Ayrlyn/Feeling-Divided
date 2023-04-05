using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour {

    public bool clone;
    public bool jump;
    public bool other;
    [SerializeField]
    float rayLength = 1.4f;
    [SerializeField]
    Transform cameraRotator = null;

    [SerializeField]
    GameObject cloner = null;
    [SerializeField]
    GameObject jumper = null;
    [SerializeField]
    GameObject otherClone = null;

    public int maxClones = 0;
    public int currentClones = 0;

    public GameObject clone1;
    public GameObject clone2;
    public GameObject clone3;

    public GameObject tutorial;

    public bool talking;

    // Use this for initialization
    void Start ()
    {
        /*
        clone = false;
        jump = false;
        other = false;
        */
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.LeftShift) && currentClones < maxClones)
        {
            if (clone1 == null || clone2 == null || clone3 == null)
                Clone();
        }
        CleanUpClones();

        if (Input.GetKeyDown(KeyCode.F) && !talking)
        {
            //These if statements have to be separated to stop a ray firing into a wall, missing the NPC but completing the statement.
            RaycastHit hit;
            if (Physics.Raycast(transform.position, cameraRotator.transform.forward, out hit, rayLength))
            {
                if (hit.transform.gameObject.tag == "NPC")
                    Talk(hit.transform.gameObject.name);
            }
            if (Physics.Raycast(transform.position, -cameraRotator.transform.forward, out hit, rayLength))
            {
                if (hit.transform.gameObject.tag == "NPC")
                    Talk(hit.transform.gameObject.name);
            }
            if (Physics.Raycast(transform.position, cameraRotator.transform.right, out hit, rayLength))
            {
                if (hit.transform.gameObject.tag == "NPC")
                    Talk(hit.transform.gameObject.name);
            }
            if (Physics.Raycast(transform.position, -cameraRotator.transform.right, out hit, rayLength))
            {
                if (hit.transform.gameObject.tag == "NPC")
                    Talk(hit.transform.gameObject.name);
            }
        }
	}

    void Clone()
    {
        GameObject clone = GameObject.Find("Cloner(Clone)");
        if (clone == null)
            clone = cloner;
        else
        {
            clone = GameObject.Find("Jumper(Clone)");
            if (clone == null)
                clone = jumper;
            else
            {
                clone = GameObject.Find("Other(Clone)");
                if (clone == null)
                    clone = otherClone;
            }
        }

        GameObject currentClone = null;
        //Clone up
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!Physics.Raycast(transform.position, cameraRotator.transform.forward, rayLength) && clone != null)
            {
                currentClone = Instantiate(clone, transform.position + cameraRotator.transform.forward, this.transform.rotation);
                currentClones++;
            }
        }
        //Clone down
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (!Physics.Raycast(transform.position, -cameraRotator.transform.forward, rayLength) && clone != null)
            {
                currentClone = Instantiate(clone, transform.position - cameraRotator.transform.forward, this.transform.rotation);
                currentClones++;
            }
        }
        //Clone left
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (!Physics.Raycast(transform.position, -cameraRotator.transform.right, rayLength) && clone != null)
            {
                currentClone = Instantiate(clone, transform.position - cameraRotator.transform.right, this.transform.rotation);
                currentClones++;
            }
        }
        //Clone right
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (!Physics.Raycast(transform.position, cameraRotator.transform.right, rayLength) && clone != null)
            {
                currentClone = Instantiate(clone, transform.position + cameraRotator.transform.right, this.transform.rotation);
                currentClones++;
            }
        }

        if (clone1 == null)
        {
            clone1 = currentClone;
        }
        else if (clone2 == null)
        {
            clone2 = currentClone;
        }
        else if (clone3 == null)
        {
            clone3 = currentClone;
        }

        clone = null;
    }

    void CleanUpClones()
    {
        if(clone1 != null)
        {
            if (clone2 != null)
            {
                if (clone1.transform.position == clone2.transform.position)
                {
                    Destroy(clone1);
                    Destroy(clone2);
                    currentClones -= 2;
                }
            }
            if (clone3 != null)
            {
                if (clone1.transform.position == clone3.transform.position)
                {
                    Destroy(clone1);
                    Destroy(clone3);
                    currentClones -= 2;
                }
            }
        }
        if (clone2 != null)
        {
            if (clone3 != null)
            {
                if (clone2.transform.position == clone3.transform.position)
                {
                    Destroy(clone2);
                    Destroy(clone3);
                    currentClones -= 2;
                }
            }
        }
    }

    void Talk(string name)
    {
        TutorialScript tutorial = GameObject.Find("Tutorial").GetComponent<TutorialScript>();
        if (!clone && name == "Cloner")
        {
            maxClones++;
            clone = true;
            GameObject.Find("Cloner").GetComponent<DialogueTrigger>().TriggerDialogue();

            tutorial.shiftBool = true;
            tutorial.shift.SetActive(true);
            tutorial.wasd.SetActive(true);
            tutorial.plus.SetActive(true);
        }
        if (!jump && name == "Jumper")
        {
            maxClones++;
            jump = true;
            GameObject.Find("Jumper").GetComponent<DialogueTrigger>().TriggerDialogue();
            tutorial.spaceBool = true;
            tutorial.space.SetActive(true);
        }
        if (name == "Gatito")
        {
            GameObject.Find("Gatito").GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        talking = true;

        if (name == "Osito")
        {
            GameObject.Find("Osito").GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        talking = true;

        if (name == "Gatito2")
        {
            GameObject.Find("Gatito2").GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        talking = true;

        if (name == "Osito2")
        {
            GameObject.Find("Osito2").GetComponent<DialogueTrigger>().TriggerDialogue();
        }
        talking = true;
    }
}
