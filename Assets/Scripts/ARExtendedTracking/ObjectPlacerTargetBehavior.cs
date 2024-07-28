using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ObjectPlacerTargetBehavior : ImageTargetBehaviour {

	private bool trackedSuccess = false;

	// Use this for initialization
	void Start () {
	}

    private void OnDestroy() {
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnTrackableStateChanged(Status previousStatus, Status newStatus) {
        if (newStatus == Status.TRACKED && this.trackedSuccess == false) {
            EventBroadcaster.Instance.PostEvent(EventNames.ExtendTrackEvents.ON_TARGET_SCAN);
            this.trackedSuccess = true;
        }
    }
}
