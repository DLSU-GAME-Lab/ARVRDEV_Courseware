using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Services;
using UnityEngine;
using Vuforia;

public class BeaconTarget : MonoBehaviour
{
    public const string BEACON_POSITION_KEY = "BEACON_POSITION_KEY";

    [SerializeField]
    private Camera arCamera;

    void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.ARPathFindEvents.ON_BEACON_DETECTED, this.FoundCaller);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FoundCaller()
    {
        Invoke("OnBeaconFound", 0.2f);
    }

    private void OnBeaconFound()
    {
        Debug.Log("Hilo ther");
        

        Parameters parameters = new Parameters();
        Vector3 trackedPos = this.TranslateBeaconPosition();
        parameters.PutObjectExtra(BEACON_POSITION_KEY, trackedPos);
        EventBroadcaster.Instance.PostEvent(EventNames.ARPathFindEvents.ON_BEACON_DETECTED, parameters);
    }

    private Vector3 TranslateBeaconPosition()
    {
        
        Debug.Log("Hilo ther again");
        Ray ray= this.arCamera.ScreenPointToRay(this.arCamera.WorldToScreenPoint(this.transform.position));
        Debug.Log("Hilo there again again");
        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        RaycastHit hit;
        Vector3 hitPos = Vector3.zero;
        if(Physics.Raycast(ray, out hit))
        {
            hitPos=hit.point;
            Debug.Log("Hit pos: "+hitPos+" at object: "+ hit.transform.gameObject.name);
        }
        return hitPos;  
    }


}
