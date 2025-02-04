using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class ClawController : MonoBehaviour
{

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

    public float craneMoveSpeed = 0.4f;

    private bool releasePressed = false;
    private float releaseTimer = 0.0f;
    private float releaseDuration = 1f;

    //Checks if the button for grabbing has been pressed
    //Attached to the grab button within the UI
    public void OnDropPressed()
    {
        dropPressed = true;
    }

    // Implements the movement of claw grabbing. Drops claw, then closes the claw, then moves towards the prize box.
    void Update()
    {

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
                        if (CraneParent.transform.localPosition.x > 0.0f)
                        {
                            CraneParent.transform.localPosition =CraneParent.transform.localPosition +Vector3.left*craneMoveSpeed * Time.deltaTime;
                        }
                        else if (CraneParent.transform.localPosition.z > -0.93f)
                        {
                            CraneParent.transform.localPosition =CraneParent.transform.localPosition + Vector3.back *craneMoveSpeed* Time.deltaTime;
                        }
                        else if (releaseTimer < releaseDuration)
                        {
                            Claw1.transform.Rotate(Vector3.left, clawRotationSpeed * Time.deltaTime);
                            Claw2.transform.Rotate(Vector3.left, clawRotationSpeed * Time.deltaTime);
                            Claw3.transform.Rotate(Vector3.left, clawRotationSpeed * Time.deltaTime);
                            Claw4.transform.Rotate(Vector3.left, clawRotationSpeed * Time.deltaTime);
                            releaseTimer += Time.deltaTime;
                        }
                        else
                        {
                            dropPressed = false;
                            clawOpenTimer = 0.0f;
                            dropTimer = 0.0f;
                            liftTimer = 0.0f;
                            releaseTimer = 0.0f;
                        }
                    }
                }
            }
        }
    }


}
