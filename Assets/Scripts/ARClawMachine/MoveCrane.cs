using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;

public class MoveCrane : MonoBehaviour
{
    [SerializeField]
    private GameObject CraneParent;
    public float craneMoveSpeed = 0.4f;
    private bool buttonHeld = false;
    private float worldPositionX;
    private float worldPositionZ;

    // Start is called before the first frame update
    void Start()
    {
        worldPositionX = CraneParent.transform.position.x;
        worldPositionZ = CraneParent.transform.position.z;
    }
    // Attached to a move button in the UI(Pointer Down in Event Trigger Component)
    // Detects whether a button is pressed and held down.
    public void ButtonHeld()
    {
        buttonHeld = true;
    }
    // Attached to a move button in the UI(Pointer Up in Event Trigger Component)
    // Detects whether a button is released.
    public void ButtonReleased()
    {
        buttonHeld = false;
    }
    // Update is called once per frame
    // Determines which movement function to call depending on the name of the button.
    void Update()
    {
        if(buttonHeld)
        {
            if(this.name=="Left")
            {
                MoveCraneLeft();
            }
            else if(this.name=="Right")
            {
                MoveCraneRight();
            }
            else if(this.name=="Up")
            {
                MoveCraneUp();
            }
            else if(this.name=="Down")
            {
                MoveCraneDown();
            }
            else
            {
                Debug.Log("Button not recognized");
            }
        }
        
    }
    // Crane movement to the left.
    public void MoveCraneLeft()
    {
        Vector3 movement = CraneParent.transform.position + Vector3.left * craneMoveSpeed * Time.deltaTime;

        if (movement.x-worldPositionX > 0f)
        {
            CraneParent.GetComponent<Rigidbody>().MovePosition(movement);
        }
    }
    // Crane movement to the right.
    public void MoveCraneRight() {
        Vector3 movement = CraneParent.transform.position + Vector3.right * craneMoveSpeed * Time.deltaTime;

        if (movement.x -worldPositionX < 1.4f)
        {
            CraneParent.GetComponent<Rigidbody>().MovePosition(movement);
        }
    }
    // Crane movement upwards.
    public void MoveCraneUp() {
        Vector3 movement = CraneParent.transform.position + Vector3.forward * craneMoveSpeed * Time.deltaTime;

        if (movement.z- worldPositionZ < 0f)
        {
            CraneParent.GetComponent<Rigidbody>().MovePosition(movement);
        }
    }
    // Crane movement downwards.
    public void MoveCraneDown() {
        Vector3 movement = CraneParent.transform.position + Vector3.back * craneMoveSpeed * Time.deltaTime;

        if (movement.z-worldPositionZ > -1.4f)
        {
            CraneParent.GetComponent<Rigidbody>().MovePosition(movement);
        }
    }

}
