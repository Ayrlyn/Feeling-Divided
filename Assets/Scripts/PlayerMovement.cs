using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animation animator;


    [SerializeField]
    public float moveSpeed = 0.25f;
    [SerializeField]
    float rayLength = 1.4f;
    [SerializeField]
    float rayOffsetX = 0.5f;
    [SerializeField]
    float rayOffsetY = 0.5f;
    [SerializeField]
    float rayOffsetZ = 0.5f;

    public Vector3 targetPosition;
    public Vector3 startPosition;
    public bool moving;

    public bool jumping;

    Vector3 xOffset;
    Vector3 yOffset;
    Vector3 zOffset;
    Vector3 zAxisOriginA;
    Vector3 zAxisOriginB;
    Vector3 xAxisOriginA;
    Vector3 xAxisOriginB;

    [SerializeField]
    Transform cameraRotator = null;

    [SerializeField]
    LayerMask walkableMask = 0;

    [SerializeField]
    LayerMask collidableMask = 0;

    [SerializeField]
    float maxFallCastDistance = 100f;
    [SerializeField]
    float fallSpeed = 30f;
    bool falling;
    float targetFallHeight;

    public float currentRotation = 0f;
    public float rotateSpeed;

    public AudioSource squish;

    // Use this for initialization
    void Start ()
    {
        moving = false;
        falling = false;
        cameraRotator = GameObject.Find("CameraControl").transform;

        rotateSpeed = 0.25f;

        currentRotation = GameObject.Find("Primary").GetComponent<PlayerMovement>().currentRotation;

        squish = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
        if (falling)
        {
            if (transform.position.y <= targetFallHeight)
            {
                float x = Mathf.Round(transform.position.x);
                float y = Mathf.Round(targetFallHeight);
                float z = Mathf.Round(transform.position.z);

                transform.position = new Vector3(x, y, z);

                falling = false;

                return;
            }

            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
            return;
        }
        else if (moving)
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

        else if (jumping)
        {

            if (Vector3.Distance(startPosition, transform.position) > 2f)
            {
                float x = Mathf.Round(targetPosition.x);
                float y = Mathf.Round(targetPosition.y);
                float z = Mathf.Round(targetPosition.z);

                transform.position = new Vector3(x, y, z);

                jumping = false;
                return;
            }

            transform.position += (targetPosition - startPosition) * moveSpeed * Time.deltaTime;
            return;
        }
        else
        {
            animator.Play("Icosphere|Idle");

            RaycastHit[] hits = Physics.RaycastAll(
                transform.position + Vector3.up * 0.5f,
                Vector3.down,
                maxFallCastDistance,
                walkableMask
                );
            if (hits.Length > 0)
            {
                int topCollider = 0;
                for (int i = 0; i < hits.Length; i++)
                {
                    if (hits[topCollider].collider.bounds.max.y < hits[i].collider.bounds.max.y)
                    {
                        topCollider = i;
                    }
                }
                if (hits[topCollider].distance > 1f)
                {
                    targetFallHeight = transform.position.y - hits[topCollider].distance + 0.5f;
                    falling = true;
                }
            }
        }
        if (!moving && !Input.GetKey(KeyCode.LeftShift))
            Movement();
	}

    void Movement()
    {
        //Movement
        RaycastHit hit;
        if(Input.GetKey(KeyCode.W))
        {
            animator.Play("Icosphere|Move");
            if (!Physics.Raycast(transform.position, cameraRotator.transform.forward, rayLength))
            {
                squish.Play();
                switch (currentRotation.ToString())
                {
                    case "90":
                        StartCoroutine(RotateRight(90f));
                        break;
                    case "180":
                        StartCoroutine(RotateLeft(180f));
                        break;
                    case "270":
                        StartCoroutine(RotateLeft(90f));
                        break;
                }
                currentRotation = 0f;
                targetPosition = transform.position + cameraRotator.transform.forward;
                startPosition = transform.position;
                moving = true;
            }
            else if (Physics.Raycast(transform.position, cameraRotator.transform.forward, out hit, rayLength))
            {
                if (hit.transform.gameObject.tag == "Player")
                {
                    squish.Play();
                    switch (currentRotation.ToString())
                    {
                        case "90":
                            StartCoroutine(RotateRight(90f));
                            break;
                        case "180":
                            StartCoroutine(RotateLeft(180f));
                            break;
                        case "270":
                            StartCoroutine(RotateLeft(90f));
                            break;
                    }
                    currentRotation = 0f;
                    targetPosition = transform.position + cameraRotator.transform.forward;
                    startPosition = transform.position;
                    moving = true;
                }
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.Play("Icosphere|Move");
            if (!Physics.Raycast(transform.position, -cameraRotator.transform.forward, rayLength))
            {
                squish.Play();
                switch (currentRotation.ToString())
                {
                    case "0":
                        StartCoroutine(RotateLeft(180f));
                        break;
                    case "90":
                        StartCoroutine(RotateLeft(90f));
                        break;
                    case "270":
                        StartCoroutine(RotateRight(90f));
                        break;
                }
                currentRotation = 180f;
                targetPosition = transform.position - cameraRotator.transform.forward;
                startPosition = transform.position;
                moving = true;
            }
            else if (Physics.Raycast(transform.position, -cameraRotator.transform.forward, out hit, rayLength))
            {
                if (hit.transform.gameObject.tag == "Player")
                {
                    squish.Play();
                    switch (currentRotation.ToString())
                    {
                        case "0":
                            StartCoroutine(RotateLeft(180f));
                            break;
                        case "90":
                            StartCoroutine(RotateLeft(90f));
                            break;
                        case "270":
                            StartCoroutine(RotateRight(90f));
                            break;
                    }
                    currentRotation = 180f;
                    targetPosition = transform.position - cameraRotator.transform.forward;
                    startPosition = transform.position;
                    moving = true;
                }
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.Play("Icosphere|Move");
            if (!Physics.Raycast(transform.position, -cameraRotator.transform.right, rayLength))
            {
                squish.Play();
                switch (currentRotation.ToString())
                {
                    case "0":
                        StartCoroutine(RotateRight(90f));
                        break;
                    case "90":
                        StartCoroutine(RotateRight(180f));
                        break;
                    case "180":
                        StartCoroutine(RotateLeft(90f));
                        break;
                }
                currentRotation = 270f;
                targetPosition = transform.position - cameraRotator.transform.right;
                startPosition = transform.position;
                moving = true;
            }
            else if (Physics.Raycast(transform.position, -cameraRotator.transform.right, out hit, rayLength))
            {
                if (hit.transform.gameObject.tag == "Player")
                {
                    squish.Play();
                    switch (currentRotation.ToString())
                    {
                        case "0":
                            StartCoroutine(RotateRight(90f));
                            break;
                        case "90":
                            StartCoroutine(RotateRight(180f));
                            break;
                        case "180":
                            StartCoroutine(RotateLeft(90f));
                            break;
                    }
                    currentRotation = 270f;
                    targetPosition = transform.position - cameraRotator.transform.right;
                    startPosition = transform.position;
                    moving = true;
                }
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.Play("Icosphere|Move");
            if (!Physics.Raycast(transform.position, cameraRotator.transform.right, rayLength))
            {
                squish.Play();
                switch (currentRotation.ToString())
                {
                    case "0":
                        StartCoroutine(RotateLeft(90f));
                        break;
                    case "180":
                        StartCoroutine(RotateRight(90f));
                        break;
                    case "270":
                        StartCoroutine(RotateRight(180f));
                        break;
                }
                currentRotation = 90f;
                targetPosition = transform.position + cameraRotator.transform.right;
                startPosition = transform.position;
                moving = true;
            }
            else if (Physics.Raycast(transform.position, cameraRotator.transform.right, out hit, rayLength))
            {
                if (hit.transform.gameObject.tag == "Player")
                {
                    squish.Play();
                    switch (currentRotation.ToString())
                    {
                        case "0":
                            StartCoroutine(RotateLeft(90f));
                            break;
                        case "180":
                            StartCoroutine(RotateRight(90f));
                            break;
                        case "270":
                            StartCoroutine(RotateRight(180f));
                            break;
                    }
                    currentRotation = 90f;
                    targetPosition = transform.position + cameraRotator.transform.right;
                    startPosition = transform.position;
                    moving = true;
                }
            }
        }

        if (GameObject.Find("Primary").GetComponent<PlayerAbilities>().jump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("jump");
                if (!Physics.Raycast(transform.position, transform.forward, rayLength + 1f))
                {
                    squish.Play();
                    animator.Play("Icosphere|Jump");
                    targetPosition = transform.position + transform.forward * 2f;
                    startPosition = transform.position;
                    jumping = true;
                }
            }
        }
    }



    IEnumerator RotateLeft(float angle)
    {
        yield return StartCoroutine(MoveObject.use.Rotation(this.gameObject.transform, Vector3.down * -angle, rotateSpeed));
    }

    IEnumerator RotateRight(float angle)
    {
        yield return StartCoroutine(MoveObject.use.Rotation(this.gameObject.transform, Vector3.down * angle, rotateSpeed));
    }
}
