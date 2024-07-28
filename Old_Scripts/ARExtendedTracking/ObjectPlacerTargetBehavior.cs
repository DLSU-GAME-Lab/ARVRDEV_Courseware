using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ObjectPlacerTargetBehavior : ImageTargetBehaviour {

	private bool trackedSuccess = false;

	// Use this for initialization
	void Start () {
        this.OnTargetStatusChanged -= this.OnTrackableStateChanged;
	}

    private void OnDestroy() {
        this.OnTargetStatusChanged -= this.OnTrackableStateChanged;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnTrackableStateChanged(ObserverBehaviour behavior, TargetStatus newStatus) {
        if (newStatus.Status == Status.TRACKED && this.trackedSuccess == false) {
            EventBroadcaster.Instance.PostEvent(EventNames.ExtendTrackEvents.ON_TARGET_SCAN);
            this.trackedSuccess = true;
        }
    }
}
