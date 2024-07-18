using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;


public class ObjectPlaceScreen : MonoBehaviour {

	[SerializeField] private Text selectedText;

	private bool showToggle = true;

    // Use this for initialization
    void Awake() {
		EventBroadcaster.Instance.AddObserver (EventNames.ExtendTrackEvents.ON_TARGET_SCAN, this.OnTargetScan);
		EventBroadcaster.Instance.AddObserver(EventNames.ARMarkerless.ON_PLANE_DETECTED, this.OnPlaneFound);
        EventBroadcaster.Instance.AddObserver(EventNames.ARMarkerless.ON_PLANE_LOST, this.OnPlaneLost);
        this.gameObject.SetActive (false);
	}

	void OnDestroy() {
		EventBroadcaster.Instance.RemoveObserver (EventNames.ExtendTrackEvents.ON_TARGET_SCAN);
        EventBroadcaster.Instance.RemoveObserver(EventNames.ARMarkerless.ON_PLANE_DETECTED);
        EventBroadcaster.Instance.RemoveObserver(EventNames.ARMarkerless.ON_PLANE_DETECTED);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTargetScan() {
		this.gameObject.SetActive(true);
	}

	public void OnSelectedButton(int buildingID) {
		Debug.Log(selectedText.text);
        Debug.Log(selectedText.fontStyle);
        this.selectedText.text = "Selected: Building " + buildingID; // needs replacing, not working
        ObjectPlacerManager.Instance.SetSelected(buildingID);

		Debug.Log("Selected: Building " + buildingID);
    }

	public void OnShowHideClicked() {
		this.showToggle = !this.showToggle;

		if (this.showToggle) {
			EventBroadcaster.Instance.PostEvent (EventNames.ExtendTrackEvents.ON_SHOW_ALL);
		} else {
			EventBroadcaster.Instance.PostEvent (EventNames.ExtendTrackEvents.ON_HIDE_ALL);
		}
	}

	public void OnDeleteAll() {
		this.showToggle = true;
		EventBroadcaster.Instance.PostEvent (EventNames.ExtendTrackEvents.ON_DELETE_ALL);
	}

	public void OnImageFound() {
		InfoScreen infoScreen = (InfoScreen)ViewHandler.Instance.FindActiveView(ViewNames.INFO_SCREEN_NAME);
        infoScreen.SetVisibility(false);
		this.gameObject.SetActive(true);
		Debug.Log("Image Found");
	}

	public void OnImageLost()
    {
		InfoScreen infoScreen = (InfoScreen)ViewHandler.Instance.FindActiveView(ViewNames.INFO_SCREEN_NAME);
		infoScreen.SetVisibility(true);
        this.gameObject.SetActive(false);
		Debug.Log("Image NOT Found");
	}

	public void OnPlaneFound()
	{
        InfoScreen infoScreen = (InfoScreen)ViewHandler.Instance.FindActiveView(ViewNames.INFO_SCREEN_NAME);
        infoScreen.SetVisibility(false);
        this.gameObject.SetActive(true);
	}

    public void OnPlaneLost()
    {
        InfoScreen infoScreen = (InfoScreen)ViewHandler.Instance.FindActiveView(ViewNames.INFO_SCREEN_NAME);
        infoScreen.SetVisibility(true);
        this.gameObject.SetActive(false);
	}

}
