using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

public class PlaceObjects : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    private ARPlaneManager planeManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private List<GameObject> buildingsPlaced = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();

        EventBroadcaster.Instance.AddObserver(EventNames.ExtendTrackEvents.ON_HIDE_ALL, this.OnHideAllObjects);
        EventBroadcaster.Instance.AddObserver(EventNames.ExtendTrackEvents.ON_SHOW_ALL, this.OnShowAllObjects);
        EventBroadcaster.Instance.AddObserver(EventNames.ExtendTrackEvents.ON_DELETE_ALL, this.OnDeleteAllObjects);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.ExtendTrackEvents.ON_HIDE_ALL);
        EventBroadcaster.Instance.RemoveObserver(EventNames.ExtendTrackEvents.ON_SHOW_ALL);
        EventBroadcaster.Instance.RemoveObserver(EventNames.ExtendTrackEvents.ON_DELETE_ALL);
    }

    private void OnEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.Touch.onFingerDown += FingerDown;
    }

    private void OnDisable()
    {
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
        EnhancedTouch.Touch.onFingerDown -= FingerDown;
    }

    private void FingerDown(EnhancedTouch.Finger finger)
    {
        if (finger.index != 0) return;

        if (raycastManager.Raycast(finger.currentTouch.screenPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            foreach(ARRaycastHit hit in hits)
            {
                Pose pose = hit.pose;
                GameObject toSpawn = ObjectPlacerManager.Instance.GetObjectByID();
                GameObject obj;
                try
                {
                    obj = Instantiate(toSpawn, pose.position + toSpawn.transform.position, pose.rotation);
                    obj.SetActive(true);
                    buildingsPlaced.Add(obj);
                }
                catch (Exception e)
                {

                }
            }
        }
    }

    private void OnShowAllObjects()
    {
        buildingsPlaced.ForEach(obj =>
        {
            obj.SetActive(true);
        });
    }

    private void OnHideAllObjects()
    {
        buildingsPlaced.ForEach(obj =>
        {
            obj.SetActive(false);
        });

    }

    private void OnDeleteAllObjects()
    {
        buildingsPlaced.ForEach(obj =>
        {
            Destroy(obj);
        });
        buildingsPlaced.Clear();
    }
}
