﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PlatformTarget : ImageTargetBehaviour {

    private bool tracked = false;

    // Use this for initialization
    void Start () {
        this.OnTargetStatusChanged += this.OnTrackableStateChanged;
	}

    private void OnDestroy() {
        this.OnTargetStatusChanged -= this.OnTrackableStateChanged;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnTrackableStateChanged(ObserverBehaviour behavior, TargetStatus newStatus) {
        if (newStatus.Status == Status.TRACKED && !this.tracked) {
            this.tracked = true;
            EventBroadcaster.Instance.PostEvent(EventNames.ARPathFindEvents.ON_PLATFORM_DETECTED);

        }
        else if (newStatus.Status == Status.NO_POSE && this.tracked) {
            this.tracked = false;
            EventBroadcaster.Instance.PostEvent(EventNames.ARPathFindEvents.ON_PLATFORM_HIDDEN);
        }
    }
}
