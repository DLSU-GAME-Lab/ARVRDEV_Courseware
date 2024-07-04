using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clawspawner : MonoBehaviour
{
    [SerializeField]
    private GameObject ClawMachinePrefab;
    [SerializeField]
    private GameObject ControlScreen;
    [SerializeField]
    private GameObject PrizePrefab;
    private bool firstImageFound = false;

    [SerializeField]
    private GameObject[] prizes;


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
        if (firstImageFound == false)
        {
            GameObject.Find("InfoScreen").SetActive(false);
            ControlScreen.SetActive(true);
            ClawMachinePrefab.SetActive(true);
            firstImageFound = true;
        }
        Invoke("PrizeSpawner", 0.2f);
    }

    public void PrizeSpawner()
    {
        Debug.Log("I got here");
        for (int i = 0; i < 20; i++)
        {
            Vector3 position = new Vector3(Random.Range(-0.1f, 0.5f), 0f, Random.Range(0f, 0.5f));
            Debug.Log(position);
            prizes[i]=Instantiate(PrizePrefab,position,PrizePrefab.transform.rotation,ClawMachinePrefab.transform);
        }
    }


    public void OnImageLost()
    {
        for (int i = 0;i < prizes.Length; i++)
        {
            Destroy(prizes[i]);
        }
    }
}
