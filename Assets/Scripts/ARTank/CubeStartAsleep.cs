using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeStartAsleep : MonoBehaviour
{
    [SerializeField] private bool bRigidbodyStartAsleep = true;
    [SerializeField] private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
        if (bRigidbodyStartAsleep)
        {
            rb.useGravity = false;
            rb.Sleep();
            Debug.Log("sleeeeep");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (rb != null)
        {
            rb.WakeUp();
            rb.useGravity = true;
        }
    }

    private void OnDrawGizmos()
    {
        if (rb != null)
        {
            Gizmos.color = rb.IsSleeping() ? Color.red : Color.green;
            Gizmos.DrawWireCube(transform.position, new Vector3(0.2f, 0.2f, 0.2f));
        }
    }
}
