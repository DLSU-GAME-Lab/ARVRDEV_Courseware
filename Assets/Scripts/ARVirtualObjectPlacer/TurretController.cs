using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Camera arCamera; // AR Camera
    public GameObject[] turrets; // Array of turret GameObjects

    void Update()
    {
        Ray ray = arCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            for (int i = 0; i < turrets.Length; i++)
            {
                // Check if the hit object is a button associated with a turret
                if (hit.collider.gameObject.CompareTag("TurretButton" + i))
                {
                    FireTurret(i);
                }
            }
        }
    }

    void FireTurret(int turretIndex)
    {
        // Implement turret firing logic here
        Debug.Log("Firing turret: " + turretIndex);
        // For example, you can play a shooting animation, instantiate bullets, etc.
    }
}