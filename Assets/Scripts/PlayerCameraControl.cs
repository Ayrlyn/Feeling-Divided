using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraControl : MonoBehaviour {

    [SerializeField]
    GameObject cameraRotator = null;

    CameraRotation cameraRotation = null;

    private void Start()
    {
        cameraRotation = cameraRotator.GetComponent<CameraRotation>();
    }
}
