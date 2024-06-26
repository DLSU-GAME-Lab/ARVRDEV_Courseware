using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PlaneIndicatorManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.ARMarkerless.ON_CHANGE_BUILDING, this.ChangeSize);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.ARMarkerless.ON_CHANGE_BUILDING);
    }

    private void ChangeSize(Parameters parameters)
    {
        int buildingId = parameters.GetIntExtra(ObjectPlaceScreen.BUILDING_ID_PARAM, -1);
        Vector3 scale = new Vector3(0, 0, 0);

        switch(buildingId)
        {
            case 0:
                scale = new Vector3(0.025f, 0.01f, 0.0105f); break;
            case 1:
                scale = new Vector3(0.02f, 0.01f, 0.02f); break;
            case 2:
                scale = new Vector3(0.03f, 0.01f, 0.023f); break;
            case 3:
                scale = new Vector3(0.02f, 0.01f, 0.01f); break;
            case 4:
                scale = new Vector3(0.011f, 0.01f, 0.016f); break;
            case 5:
                scale = new Vector3(0.05f, 0.01f, 0.05f); break;
        }

        this.transform.GetChild(0).transform.GetChild(0).transform.localScale = scale;
        
    }
}
