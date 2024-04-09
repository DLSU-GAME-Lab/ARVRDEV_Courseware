using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class FirstTarget : ImageTargetBehaviour {

	// Use this for initialization
	void Start () {
        this.OnTargetStatusChanged += OnTrackableStateChanged;
    }

    private void OnDestroy() {
        this.OnTargetStatusChanged -= OnTrackableStateChanged;
    }

    public void OnTrackableStateChanged(ObserverBehaviour behavior, TargetStatus newStatus) {
        if (newStatus.Status == Status.TRACKED) {
            EventBroadcaster.Instance.PostEvent(EventNames.ARPhysicsEvents.ON_FIRST_TARGET_SCAN);
        }
    }
}
