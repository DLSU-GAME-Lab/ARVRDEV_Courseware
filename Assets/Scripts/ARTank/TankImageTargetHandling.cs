using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankImageTargetHandling : MonoBehaviour
{
    [SerializeField] private GameObject imageTarget;
    [SerializeField] private TankControls tankControls;

    public void OnTargetLost()
    {
        foreach (Transform transform in imageTarget.transform.GetComponentsInChildren<Transform>())
        {
            transform.gameObject.SetActive(false);
        }
    }

    public void OnTargetFound()
    {
        foreach (Transform transform in imageTarget.transform.GetComponentsInChildren<Transform>())
        {
            transform.gameObject.SetActive(true);
        }

        tankControls.Respawn();
    }
}
