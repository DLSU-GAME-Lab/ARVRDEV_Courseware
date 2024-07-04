using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRaycasting : MonoBehaviour
{
    public Ray ray;
    public RaycastHit hit;
    public float distance = 2000.0f;
    public GameObject latestObjHit;
    [SerializeField] LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)); // shoots ray at center of screen

        if(Physics.Raycast(ray, out hit, distance, layerMask))
        {
            Debug.Log("HIT: " + hit.transform.name);
            if(hit.collider.gameObject != latestObjHit)
            {
                if(hit.collider.gameObject.GetComponent<BaseTurret>().GetIsFiring() == false)
                {
                    hit.collider.gameObject.GetComponent<BaseTurret>().FireTurretEndless();
                    latestObjHit = hit.collider.gameObject;
                } 
                else if(hit.collider.gameObject.GetComponent<BaseTurret>().GetIsFiring() == true)
                {
                    hit.collider.gameObject.GetComponent<BaseTurret>().StopTurret();
                    latestObjHit = hit.collider.gameObject;
                }
            }
        }
        else
        {
            Debug.Log("NO HIT");
            latestObjHit = null;
        }
    }

    public void NewObjectDetection()
    {
        // must add else para pag tinanggal raycasting from latestobjdetected, mawawala rin sa temp variable yung latestobjdetected
    }
}
