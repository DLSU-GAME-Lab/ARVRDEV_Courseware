using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickPrize : MonoBehaviour
{
    [SerializeField]
    private GameObject parent;
    public void OnDisable()
    {
        if (parent.activeInHierarchy == true)
        {

            parent.SetActive(false);
        }
    }
}
