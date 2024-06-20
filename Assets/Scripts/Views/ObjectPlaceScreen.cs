using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;


public class ObjectPlaceScreen : MonoBehaviour {

	[SerializeField] private Text selectedText;

	private int eventFires = 0;

	private bool showToggle = true;

	// Use this for initialization
	void Awake() {
		EventBroadcaster.Instance.AddObserver (EventNames.ExtendTrackEvents.ON_TARGET_SCAN, this.OnTargetScan);
		this.gameObject.SetActive (false);
	}

	void OnDestroy() {
		EventBroadcaster.Instance.RemoveObserver (EventNames.ExtendTrackEvents.ON_TARGET_SCAN);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTargetScan() {
		this.gameObject.SetActive(true);
	}

	public void OnSelectedButton(int buildingID) {
		this.selectedText.text = "Selected: Building " +buildingID;
		ObjectPlacerManager.Instance.SetSelected (buildingID);
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
        this.gameObject.SetActive(false);
	}

	public void OnPlaneFound()
	{
        InfoScreen infoScreen = (InfoScreen)ViewHandler.Instance.FindActiveView(ViewNames.INFO_SCREEN_NAME);
        infoScreen.SetVisibility(false);
        this.gameObject.SetActive(true);
	}

    public void OnPlaneLost()
    {
        this.gameObject.SetActive(false);
	}

}
