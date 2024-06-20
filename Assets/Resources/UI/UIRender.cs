using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class UIRender : MonoBehaviour
{
    private void Awake()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.ExtendTrackEvents.ON_TARGET_SCAN, this.OnTargetScan);
    }

    private void OnDisable()
    {
        EventBroadcaster.Instance.RemoveActionAtObserver(EventNames.ExtendTrackEvents.ON_TARGET_SCAN, this.OnTargetScan);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveActionAtObserver(EventNames.ExtendTrackEvents.ON_TARGET_SCAN, this.OnTargetScan);
    }

    private void OnTargetScan()
    {
        this.gameObject.SetActive(true);
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
