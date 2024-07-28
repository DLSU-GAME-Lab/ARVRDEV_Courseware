using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class EnemySpawnTarget : ImageTargetBehaviour {

    private EnemySpawnManager spawnManager;
    private bool activated = false;

	// Use this for initialization
	void Start () {
        this.spawnManager = this.transform.Find("Container").GetComponent<EnemySpawnManager>();
        this.spawnManager.gameObject.SetActive(false);

        this.OnTargetStatusChanged += this.OnTrackableStateChanged;
	}

    private void OnDestroy() {
        this.OnTargetStatusChanged -= this.OnTrackableStateChanged;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnTrackableStateChanged(ObserverBehaviour behavior, TargetStatus newStatus) {
        if (newStatus.Status == Status.TRACKED && !this.activated) {
            this.spawnManager.gameObject.SetActive(true);
            this.activated = true;
        }
        else if (newStatus.Status == Status.NO_POSE && this.activated) {
            this.spawnManager.gameObject.SetActive(false);
            this.activated = false;
        }
    }
}
