using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class FirstTarget : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
    }

    private void OnDestroy() {
        
    }

    public void OnTargetFound() {
        EventBroadcaster.Instance.PostEvent(EventNames.ARPhysicsEvents.ON_FIRST_TARGET_SCAN);
    }
}
