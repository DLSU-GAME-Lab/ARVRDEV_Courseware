﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScreen : View {

	// Use this for initialization
	void Start () {
	}

	public void On3DImageClicked() {
		LoadManager.Instance.LoadScene(SceneNames.ROTATE_OBJECT_SCENE);
	}

	public void OnPhysicsARClicked() {
		LoadManager.Instance.LoadScene (SceneNames.AR_PHYSICS_SCENE);
	}

	public void OnExtendedTrackingClicked() {
		LoadManager.Instance.LoadScene (SceneNames.AR_EXTENDED_TRACKING_SCENE);
	}

    public void OnObjectPlacerClicked() {
        LoadManager.Instance.LoadScene(SceneNames.AR_OBJECT_PLACER_SCENE);
    }

	public void OnOcclusionClicked() {
		LoadManager.Instance.LoadScene (SceneNames.OCCLUSION_SCENE);
	}

	public void OnARMarkerlessClicked() {
		LoadManager.Instance.LoadScene (SceneNames.AR_MARKERLESS_SCENE);
	}

	public void OnBluetoothDemoClicked() {
		LoadManager.Instance.LoadScene (SceneNames.BLUETOOTH_AR_SCENE);
	}

    public void OnARVideoPlaybackClicked() {
        LoadManager.Instance.LoadScene(SceneNames.AR_VIDEO_PLAYBACK);
    }

    public void OnARPathfindingClicked() {
        LoadManager.Instance.LoadScene(SceneNames.AR_PATH_FINDING);
    }

    public void OnMoleculeViewerClicked() {
        LoadManager.Instance.LoadScene(SceneNames.AR_MOLECULE_VIEWER);
    }

    public void OnWreckBallClicked() {
        LoadManager.Instance.LoadScene(SceneNames.AR_WRECKING_BALL_SCENE);
    }

    public void OnClawMachineClicked()
    {
        LoadManager.Instance.LoadScene(SceneNames.AR_CLAW_MACHINE);
    }

    public void OnARBoxClicked() {
        LoadManager.Instance.LoadScene(SceneNames.AR_BOX_SCENE);
    }

    public void OnARMultipleTextboxClicked()
    {
        LoadManager.Instance.LoadScene(SceneNames.AR_MULTIPLE_TEXTBOX);
    }
	
    public void OnARCoinPusherClicked()
    {
        LoadManager.Instance.LoadScene(SceneNames.AR_COIN_PUSHER);
    }
    public void OnARTankClicked()
    {
        LoadManager.Instance.LoadScene(SceneNames.AR_TANK);
    }

    public void OnARMultiplayer()
    {
        LoadManager.Instance.LoadScene(SceneNames.AR_MULTIPLAYER);
    }

    public void OnAsteroids()
    {
        LoadManager.Instance.LoadScene(SceneNames.AR_ASTEROIDS);
    }

    public void OnARPhotorealismClicked() {
        LoadManager.Instance.LoadScene(SceneNames.AR_PHOTOREALISM_SCENE);
    }

    public void OnSogangButtonClicked() {
        LoadManager.Instance.LoadScene(SceneNames.AR_IMAGE_VIEWER_SCENE);
    }

	public override void OnRootScreenBack ()
	{
		DialogInterface dialog = DialogBuilder.Create (DialogBuilder.DialogType.CHOICE_DIALOG);
		dialog.SetMessage ("Exit the application?");
		dialog.SetOnConfirmListener (() => {
			Application.Quit();
		});
	}
}
