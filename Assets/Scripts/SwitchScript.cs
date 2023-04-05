using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour {

    public GameObject player;
    public GameObject clone1;
    public GameObject clone2;

    public bool pressed;
    public bool playedSound;

    AudioSource beep;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Primary");
        beep = this.GetComponent<AudioSource>();
        playedSound = false;
	}
	
	// Update is called once per frame
	void Update () {
        pressed = false;
        clone1 = GameObject.Find("Cloner(Clone)");
        clone2 = GameObject.Find("Jumper(Clone)");

        if (player.transform.position.x == this.transform.position.x && player.transform.position.z == this.transform.position.z)
        {
            pressed = true;
            if(!playedSound)
            {
                beep.Play();
                playedSound = true;
            }
        }
        if (clone1 != null)
        {
            if (clone1.transform.position.x == this.transform.position.x && clone1.transform.position.z == this.transform.position.z)
            {
                pressed = true;
                if (!playedSound)
                {
                    beep.Play();
                    playedSound = true;
                }
            }
        }
        if (clone2 != null)
        {
            if (clone2.transform.position.x == this.transform.position.x && clone2.transform.position.z == this.transform.position.z)
            {
                pressed = true;
                if (!playedSound)
                {
                    beep.Play();
                    playedSound = true;
                }
            }
        }
    }
}
