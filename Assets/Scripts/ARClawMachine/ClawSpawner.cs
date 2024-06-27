using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clawspawner : MonoBehaviour
{
    [SerializeField]
    private GameObject ClawMachinePrefab;
    [SerializeField]
    private GameObject ControlScreen;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnImageFound()
    {
        GameObject.Find("InfoScreen").SetActive(false);
        ControlScreen.SetActive(true);
        ClawMachinePrefab.SetActive(true);
    }


    public void OnImageLost()
    {
        ControlScreen.SetActive(false);
        ClawMachinePrefab.SetActive(false);
    }
}
