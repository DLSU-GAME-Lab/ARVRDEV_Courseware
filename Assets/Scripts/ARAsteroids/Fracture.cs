using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fracture : MonoBehaviour
{
    [Tooltip("\"Fractured\" is the object that this will break into")]
    public GameObject fractured;

    public void FractureObject()
    {
        GameObject obj = Instantiate(fractured, transform.position, transform.rotation); //Spawn in the broken version
        foreach(Transform t in obj.transform)
        {
            t.GetComponent<Rigidbody>().AddExplosionForce(150.0f, this.transform.position, 50.0f);
        }
        Destroy(gameObject); //Destroy the object to stop it getting in the way
    }
}
