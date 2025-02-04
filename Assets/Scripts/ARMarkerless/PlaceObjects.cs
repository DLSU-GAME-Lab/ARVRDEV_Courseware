using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceObjects : MonoBehaviour
{
    private ARRaycastManager raycastManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private List<GameObject> buildingsPlaced = new List<GameObject>();

    private bool isActive = true;

    // Start is called before the first frame update
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();

        EventBroadcaster.Instance.AddObserver(EventNames.ExtendTrackEvents.ON_HIDE_ALL, this.OnHideAllObjects);
        EventBroadcaster.Instance.AddObserver(EventNames.ExtendTrackEvents.ON_SHOW_ALL, this.OnShowAllObjects);
        EventBroadcaster.Instance.AddObserver(EventNames.ExtendTrackEvents.ON_DELETE_ALL, this.OnDeleteAllObjects);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (raycastManager.Raycast(Input.mousePosition, hits, TrackableType.PlaneWithinPolygon))
            {
                foreach (ARRaycastHit hit in hits)
                {
                    Pose pose = hit.pose;
                    GameObject toSpawn = ObjectPlacerManager.Instance.GetObjectByID();
                    GameObject obj;

                    if (toSpawn == null) return;

                    obj = Instantiate(toSpawn, pose.position + toSpawn.transform.position, pose.rotation);
                    obj.SetActive(isActive);
                    buildingsPlaced.Add(obj);
                }
            }
        }
    }
    private void OnShowAllObjects()
    {
        isActive = true;
        buildingsPlaced.ForEach(obj =>
        {
            obj.SetActive(isActive);
        });
    }

    private void OnHideAllObjects()
    {
        isActive = false;
        buildingsPlaced.ForEach(obj =>
        {
            obj.SetActive(isActive);
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
