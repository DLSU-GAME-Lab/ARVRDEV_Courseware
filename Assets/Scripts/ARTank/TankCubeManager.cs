using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// gets all child objects and their starting positions
public class TankCubeManager : MonoBehaviour
{
    [SerializeField] private GameObject cubeParent;

    private Dictionary<GameObject, Vector3> cubePositions = new Dictionary<GameObject, Vector3>();

    private void Start()
    {
        foreach (Transform cubeTransform in cubeParent.transform.GetComponentsInChildren<Transform>())
        {
            cubePositions.Add(cubeTransform.gameObject, cubeTransform.position);
        }
    }

    public void ResetCubes()
    {
        foreach (GameObject gameObject in cubePositions.Keys)
        {
            gameObject.transform.position = cubePositions[gameObject];
            gameObject.GetComponent<Rigidbody>().Sleep();
        }
    }
}
