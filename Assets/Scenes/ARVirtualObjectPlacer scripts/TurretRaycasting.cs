using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRaycasting : MonoBehaviour
{
    public Ray ray;
    public RaycastHit hit;
    public float distance = 2000.0f;
    [SerializeField] LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)); // shoots ray at center of screen
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(ray, out hit, distance, layerMask))
        {
            
            Debug.Log("HIT: " + hit.transform.name);
        }
    }
}
