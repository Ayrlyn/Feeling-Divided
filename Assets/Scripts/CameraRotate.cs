using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour {

    [SerializeField]
    float rotateSpeed = 0.125f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(RotateLeft());
            StartCoroutine(RotatePlayerLeft());
            StartCoroutine(RotateClonerLeft());
            StartCoroutine(RotateJumperLeft());
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(RotateRight());
            StartCoroutine(RotatePlayerRight());
            StartCoroutine(RotateClonerRight());
            StartCoroutine(RotateJumperRight());
        }
        */
	}

    IEnumerator RotateLeft()
    {
        yield return StartCoroutine(MoveObject.use.Rotation(gameObject.transform, Vector3.down * -90f, rotateSpeed));
    }

    IEnumerator RotateRight()
    {
        yield return StartCoroutine(MoveObject.use.Rotation(gameObject.transform, Vector3.down * 90f, rotateSpeed));
    }

    IEnumerator RotatePlayerLeft()
    {
        yield return StartCoroutine(MoveObject.use.Rotation(GameObject.Find("Primary").transform, Vector3.down * -90f, rotateSpeed));
    }

    IEnumerator RotatePlayerRight()
    {
        yield return StartCoroutine(MoveObject.use.Rotation(GameObject.Find("Primary").transform, Vector3.down * 90f, rotateSpeed));
    }

    IEnumerator RotateClonerLeft()
    {
        if (GameObject.Find("Cloner(Clone)") != null)
        {
            yield return StartCoroutine(MoveObject.use.Rotation(GameObject.Find("Cloner(Clone)").transform, Vector3.down * -90f, rotateSpeed));
        }
    }

    IEnumerator RotateClonerRight()
    {
        if (GameObject.Find("Cloner(Clone)") != null)
        {
            yield return StartCoroutine(MoveObject.use.Rotation(GameObject.Find("Cloner(Clone)").transform, Vector3.down * 90f, rotateSpeed));
        }
    }



    IEnumerator RotateJumperLeft()
    {
        if (GameObject.Find("Jumper(Clone)") != null)
        {
            yield return StartCoroutine(MoveObject.use.Rotation(GameObject.Find("Jumper(Clone)").transform, Vector3.down * -90f, rotateSpeed));
        }
    }

    IEnumerator RotateJumperRight()
    {
        if (GameObject.Find("Jumper(Clone)") != null)
        {
            yield return StartCoroutine(MoveObject.use.Rotation(GameObject.Find("Jumper(Clone)").transform, Vector3.down * 90f, rotateSpeed));
        }
    }
}
