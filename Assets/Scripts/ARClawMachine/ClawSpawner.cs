using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using System.Threading;
public class Clawspawner : MonoBehaviour
{
    [SerializeField]
    private GameObject ClawMachinePrefab;
    [SerializeField]
    private GameObject ControlScreen;
    [SerializeField]
    private GameObject[] PrizePrefabs;
    private bool firstImageFound = false;

    private GameObject[] prizeList = new GameObject[60];

    //Attached to image target on found.
    //Changes the UI and calls the prize spawning function.
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

    //Function that spawns all of the prizes
    public void PrizeSpawner()
    {
        for (int i = 0; i < 50; i++)
        {
            Vector3 position=new Vector3(0,0, 0);
            do
            {
                position = new Vector3(Random.Range(-0.58f, 0.9f), Random.Range(-0.2f,0.2f), Random.Range(-0.46f, 1.1f));
            } while ((position.x < -0.35f && position.z < 0.12) || (position.x < -0.08f && position.z < -0.09f));
            
            GameObject temp = Instantiate(PrizePrefabs[Random.Range(0,PrizePrefabs.Length)], ClawMachinePrefab.transform);
            temp.transform.localPosition = position;
            prizeList[i] = temp;
        }
    }
    //Attached to image target on image lost
    //Destroys all prizes when the imagetarget is lost.
    public void OnImageLost()
    {
        PrizeDestroy();
    }

    //Destroys all prizes
    public void PrizeDestroy()
    {
        for (int i = 0; i < prizeList.Length; i++)
        {
            Destroy(prizeList[i]);
        }
    }
    //Attached to reset button.
    //Destroys then spawns all the prizes in again afterwards.
    public void PrizeReset()
    {
        PrizeDestroy();
        PrizeSpawner();
    }
}
