using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private GameObject[] prizeList = new GameObject[30];


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
        for (int i = 0; i < 20; i++)
        {
            Vector3 position = new Vector3(Random.Range(-0.1f, 0.7f), 0f, Random.Range(0f, 0.7f));
            GameObject temp=Instantiate(PrizePrefab, position, PrizePrefab.transform.rotation, ClawMachinePrefab.transform);
            prizeList[i] = temp;
            
        }
    }


    public void OnImageLost()
    {
        PrizeDestroy();
    }

    public void PrizeDestroy()
    {
        for (int i = 0; i < prizeList.Length; i++)
        {
            Destroy(prizeList[i]);
        }
    }
}
