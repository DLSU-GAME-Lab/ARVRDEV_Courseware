using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundObjectHandler : MonoBehaviour
{
    private GameObject child;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            child = Instantiate(ObjectPlacerManager.Instance.GetObjectByID(), this.transform);
            child.SetActive(true);
        }
        catch (Exception e)
        { 
            Destroy(gameObject);
        }

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

    private void OnShowAllObjects()
    {
        this.gameObject.SetActive(true);
    }

    private void OnHideAllObjects()
    {
        this.gameObject.SetActive(false);

    }

    private void OnDeleteAllObjects()
    {
        Destroy(this.gameObject);
    }
}
