using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class ClawController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject Claw1;
    [SerializeField]
    private GameObject Claw2;
    [SerializeField]
    private GameObject Claw3;
    [SerializeField]
    private GameObject Claw4;
    [SerializeField]
    private GameObject CraneParent;



    private bool dropPressed = false;
    public float clawRotationSpeed = 32f;
    public float craneDropSpeed = 2.9f;

    private float clawOpenTimer = 0.0f;
    public float clawRotationDuration = 1f;

    private float dropTimer = 0.0f;
    public float dropDuration = 1f;

    private float liftTimer = 0.0f;
    public float liftDuration = 0.5f;

    private bool releasePressed = false;
    private float releaseTimer = 0.0f;
    private float releaseDuration = 1f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log(CraneParent.transform.position);
            Debug.Log(CraneParent.transform.localPosition);
        }

        if (dropPressed == true)
        {
            dropTimer += Time.deltaTime;
            if (dropTimer < dropDuration)
            {
                CraneParent.transform.position = CraneParent.transform.position + Vector3.down * craneDropSpeed * Time.deltaTime;
            }
            else
            {
                clawOpenTimer += Time.deltaTime;
                if (clawOpenTimer < clawRotationDuration)
                {
                    Claw1.transform.Rotate(Vector3.right, clawRotationSpeed * Time.deltaTime);
                    Claw2.transform.Rotate(Vector3.right, clawRotationSpeed * Time.deltaTime);
                    Claw3.transform.Rotate(Vector3.right, clawRotationSpeed * Time.deltaTime);
                    Claw4.transform.Rotate(Vector3.right, clawRotationSpeed * Time.deltaTime);
                }
                else
                {
                    liftTimer += Time.deltaTime;
                    if (liftTimer < liftDuration)
                    {
                        CraneParent.transform.position = CraneParent.transform.position + Vector3.up * craneDropSpeed * Time.deltaTime;
                    }
                    else
                    {
                        dropPressed = false;
                        clawOpenTimer = 0.0f;
                        dropTimer = 0.0f;
                        liftTimer = 0.0f;
                    }
                }
            }
        }

        if (releasePressed == true)
        {
            releaseTimer += Time.deltaTime;
            if (releaseTimer < releaseDuration)
            {
                Claw1.transform.Rotate(Vector3.left, clawRotationSpeed * Time.deltaTime);
                Claw2.transform.Rotate(Vector3.left, clawRotationSpeed * Time.deltaTime);
                Claw3.transform.Rotate(Vector3.left, clawRotationSpeed * Time.deltaTime);
                Claw4.transform.Rotate(Vector3.left, clawRotationSpeed * Time.deltaTime);
            }
            else
            {
                releaseTimer=0.0f;
                releasePressed = false;
            }
        }

    }

    public void OnDropPressed()
    {
        dropPressed = true;
    }

    public void OnReleasePressed()
    {
        releasePressed = true;
    }
}
