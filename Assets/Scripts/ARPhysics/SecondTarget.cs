using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SecondTarget : ImageTargetBehaviour {

    // Use this for initialization

	void Start () {
        this.OnTargetStatusChanged -= this.OnTrackableStateChanged;
	}

    private void OnDestroy() {
        this.OnTargetStatusChanged -= this.OnTrackableStateChanged;
    }

    public void OnTrackableStateChanged(ObserverBehaviour behavior, TargetStatus newStatus) {
        if (newStatus.Status == Status.TRACKED) {
            EventBroadcaster.Instance.PostEvent(EventNames.ARPhysicsEvents.ON_FINAL_TARGET_SCAN);
        }
    }
}
