using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class WreckingBallTargetHandler : ImageTargetBehaviour {

    private WreckingBallPlacer wreckingBallPlacer;

	// Use this for initialization
	void Start () {
        this.wreckingBallPlacer = this.transform.Find("WBPlatform").GetComponent<WreckingBallPlacer>();
        this.wreckingBallPlacer.gameObject.SetActive(false);

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
            this.wreckingBallPlacer.gameObject.SetActive(true);
            this.wreckingBallPlacer.PlotWreckingBall();
        }
        else if (newStatus.Status == Status.NO_POSE) {
            this.wreckingBallPlacer.gameObject.SetActive(false);
            this.wreckingBallPlacer.MarkTargetLost();
        }
    }
}
