using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZAxisMiovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("The speed at which the object moves back and forth.")]
    public float speed = 2.0f;

    [Tooltip("The distance the object moves from its starting position.")]
    public float range = 1.0f;

    private Vector3 startPosition;

    void Start()
    {
        // Store the starting position of the object
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new Z position using a sine wave for smooth back-and-forth motion
        float zOffset = Mathf.Sin(Time.time * speed) * range;

        // Update the object's position
        transform.position = new Vector3(startPosition.x, startPosition.y, startPosition.z + zOffset);
    }
}
