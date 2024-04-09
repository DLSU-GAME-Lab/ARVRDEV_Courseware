using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class BeaconTarget : MonoBehaviour {

    public const string BEACON_POSITION_KEY = "BEACON_POSITION_KEY";
    [SerializeField] private PlatformTarget platformTarget;
    [SerializeField] private Camera arCamera;

    private bool tracked = true;
    private ObserverBehaviour mTrackableBehaviour;


    // Use this for initialization
    void Start () {
        mTrackableBehaviour = GetComponent<ObserverBehaviour>();
        if (mTrackableBehaviour)
            this.mTrackableBehaviour.OnTargetStatusChanged += MTrackableBehaviour_OnTargetStatusChanged;
    }

    private void MTrackableBehaviour_OnTargetStatusChanged(ObserverBehaviour behavior, TargetStatus newStatus)
    {
        if (newStatus.Status == Status.TRACKED)
        {
            this.tracked = true;
            Parameters parameters = new Parameters();
            Vector3 trackedPos = this.TranslateBeaconPosition();
            parameters.PutObjectExtra(BEACON_POSITION_KEY, trackedPos);
            EventBroadcaster.Instance.PostEvent(EventNames.ARPathFindEvents.ON_BEACON_DETECTED, parameters);
        }
        else if (newStatus.Status == Status.NO_POSE)
        {
            this.tracked = false;
        }
    }

    private void OnDestroy() {
       this.mTrackableBehaviour.OnTargetStatusChanged -= MTrackableBehaviour_OnTargetStatusChanged;
    }

    // Update is called once per frame
    void Update () {
		
	}

    private Vector3 TranslateBeaconPosition() {
        Ray ray = this.arCamera.ScreenPointToRay(this.arCamera.WorldToScreenPoint(this.transform.position));
        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        RaycastHit hit;
        Vector3 hitPos = Vector3.zero;
        if (Physics.Raycast(ray, out hit)) {
            hitPos = hit.point;
            Debug.Log("Hit pos: " + hitPos + " at object: " + hit.transform.gameObject.name);
        }

        return hitPos;
    }
}
