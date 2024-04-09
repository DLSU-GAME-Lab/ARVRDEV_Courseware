using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VideoTargetRef : ImageTargetBehaviour {

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
        if (newStatus.Status == Status.TRACKED) {
            VideoSizeComputer.Instance.OnDetected(this);
        }
    }
}
