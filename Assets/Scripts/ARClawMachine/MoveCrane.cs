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
    public float craneMoveSpeed = 10.0f;
    private bool buttonHeld = false;
    private float worldPositionX;
    private float worldPositionZ;

    // Start is called before the first frame update
    void Start()
    {
        worldPositionX = CraneParent.transform.position.x;
        worldPositionZ = CraneParent.transform.position.z;
    }

    // Update is called once per frame
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

    public void ButtonHeld()
    {
        buttonHeld = true;
    }

    public void ButtonReleased()
    {
        buttonHeld = false;
    }

    public void MoveCraneLeft()
    {
        Vector3 movement = CraneParent.transform.position + Vector3.left * craneMoveSpeed * Time.deltaTime;

        if (movement.x-worldPositionX > 0f)
        {
            CraneParent.GetComponent<Rigidbody>().MovePosition(movement);
        }
    }
    public void MoveCraneRight() {
        Vector3 movement = CraneParent.transform.position + Vector3.right * craneMoveSpeed * Time.deltaTime;

        if (movement.x -worldPositionX < 1.4f)
        {
            CraneParent.GetComponent<Rigidbody>().MovePosition(movement);
        }
    }
    public void MoveCraneUp() {
        Vector3 movement = CraneParent.transform.position + Vector3.forward * craneMoveSpeed * Time.deltaTime;

        if (movement.z- worldPositionZ < 0f)
        {
            CraneParent.GetComponent<Rigidbody>().MovePosition(movement);
        }
    }
    public void MoveCraneDown() {
        Vector3 movement = CraneParent.transform.position + Vector3.back * craneMoveSpeed * Time.deltaTime;

        if (movement.z-worldPositionZ > -1.4f)
        {
            CraneParent.GetComponent<Rigidbody>().MovePosition(movement);
        }
    }

}
