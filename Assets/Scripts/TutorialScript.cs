using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour {

    public GameObject player;
    public GameObject w;
    public GameObject a;
    public GameObject s;
    public GameObject d;

    public bool shiftBool;
    public GameObject shift;
    public GameObject wasd;
    public GameObject plus;

    public bool ctrlBool;
    public GameObject ctrl;

    public bool spaceBool;
    public GameObject space;

	// Use this for initialization
	void Start () {
		shiftBool = false;
        shift.SetActive(false);
        wasd.SetActive(false);
        plus.SetActive(false);
        ctrl.SetActive(false);

        spaceBool = false;
        space.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = player.transform.position;

        MoveTutorial();

        if (shiftBool)
            CloneTutorial();

        if (ctrlBool)
            DismissTutorial();

        if (spaceBool)
            JumpTutorial();
	}

    void MoveTutorial()
    {
        if (w.activeSelf && Input.GetKeyDown(KeyCode.W))
            w.SetActive(false);

        else if (a.activeSelf && Input.GetKeyDown(KeyCode.A))
            a.SetActive(false);

        else if (s.activeSelf && Input.GetKeyDown(KeyCode.S))
            s.SetActive(false);

        else if (d.activeSelf && Input.GetKeyDown(KeyCode.D))
            d.SetActive(false);
    }

    void CloneTutorial()
    {
        if (shift.activeSelf && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.W))
        {
            shift.SetActive(false);
            plus.SetActive(false);
            wasd.SetActive(false);
            shiftBool = false;
            ctrlBool = true;
            ctrl.SetActive(true);
        }
        else if (shift.activeSelf && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.A))
        {
            shift.SetActive(false);
            plus.SetActive(false);
            wasd.SetActive(false);
            shiftBool = false;
            ctrlBool = true;
            ctrl.SetActive(true);
        }

        else if (shift.activeSelf && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.S))
        {
            shift.SetActive(false);
            plus.SetActive(false);
            wasd.SetActive(false);
            shiftBool = false;
            ctrlBool = true;
            ctrl.SetActive(true);
        }

        else if (shift.activeSelf && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.D))
        {
            shift.SetActive(false);
            plus.SetActive(false);
            wasd.SetActive(false);
            shiftBool = false;
            ctrlBool = true;
            ctrl.SetActive(true);
        }
    }

    void DismissTutorial()
    {
        if (ctrl.activeSelf && Input.GetKeyDown(KeyCode.LeftControl))
        {
            ctrl.SetActive(false);
            ctrlBool = false;
        }
    }

    void JumpTutorial()
    {
        if(space.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            space.SetActive(false);
            spaceBool = false;
        }
    }
}
