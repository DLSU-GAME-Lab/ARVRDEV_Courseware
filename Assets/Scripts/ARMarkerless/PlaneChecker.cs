using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaneChecker : MonoBehaviour
{
    private ARPlaneManager planeManager;
    private bool isPlaneDetected = false;

    // Start is called before the first frame update
    void Start()
    {
        planeManager = GetComponent<ARPlaneManager>();
        planeManager.planesChanged += DetectFirstPlaneAdded;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DetectFirstPlaneAdded (ARPlanesChangedEventArgs args)
    {
        if (planeManager.trackables.count > 0 && !isPlaneDetected)
        {
            isPlaneDetected = true;
            EventBroadcaster.Instance.PostEvent(EventNames.ARMarkerless.ON_PLANE_DETECTED);
        }
        else if (planeManager.trackables.count <= 0)
        {
            isPlaneDetected = false;
            EventBroadcaster.Instance.PostEvent(EventNames.ARMarkerless.ON_PLANE_LOST);
        }
    }
}
