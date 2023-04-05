using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPuzzle : MonoBehaviour {

    public GameObject[] switches;

    public int requiredSwitches;
    public int pressedSwitches;

    public Animator animator;

    // Use this for initialization
    void Start () {
        requiredSwitches = switches.Length / 2;
    }
	
	// Update is called once per frame
	void Update () {
        CountSwitches();
	}

    void CountSwitches()
    {
        pressedSwitches = 0;
        foreach (GameObject g in switches)
        {
            if (g.GetComponent<SwitchScript>().pressed)
            {
                pressedSwitches++;
            }
        }
        if (pressedSwitches >= requiredSwitches)
        {
            LowerBarriers();
        }
    }

    void LowerBarriers()
    {
        animator.SetBool("Switch", true);
    }
}
