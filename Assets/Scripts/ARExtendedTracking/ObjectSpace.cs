
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the logic for placing virtual objects through screen tap.
/// By: NeilDG
/// </summary>
public class ObjectSpace : MonoBehaviourPun {

	[SerializeField] private Camera arCamera;

    private Vector3 cameraOffset = new Vector3(0, -8.0f, 0);
	private List<GameObject> placedObjects;

	private const byte OBJECT_PLACE_EVENT = 1;
	private const byte DELETE_ALL_EVENT=2;

	// Use this for initialization
	void Start () {
		//TEST for object selection here
		//ObjectPlacerManager.Instance.SetSelected (5);

		this.placedObjects = new List<GameObject> ();

        PhotonNetwork.NetworkingClient.EventReceived += NetworkingClient_EventReceived;
        


        EventBroadcaster.Instance.AddObserver (EventNames.ExtendTrackEvents.ON_HIDE_ALL, this.OnHideAllObjects);
		EventBroadcaster.Instance.AddObserver (EventNames.ExtendTrackEvents.ON_SHOW_ALL, this.OnShowAllObjects);
		EventBroadcaster.Instance.AddObserver (EventNames.ExtendTrackEvents.ON_DELETE_ALL, this.OnDeleteAllClicked);
	}

    void OnDestroy() {
        PhotonNetwork.NetworkingClient.EventReceived -= NetworkingClient_EventReceived;
        EventBroadcaster.Instance.RemoveObserver (EventNames.ExtendTrackEvents.ON_HIDE_ALL);
		EventBroadcaster.Instance.RemoveObserver (EventNames.ExtendTrackEvents.ON_SHOW_ALL);
		EventBroadcaster.Instance.RemoveObserver (EventNames.ExtendTrackEvents.ON_DELETE_ALL);
	}

    private void NetworkingClient_EventReceived(EventData obj)
    {
		if (obj.Code == OBJECT_PLACE_EVENT)
		{
			object[] datas =(object[]) obj.CustomData;
			Vector3 position =(Vector3) datas[0];
			int ObjectID = (int) datas[1];
			ObjectPlacerManager.Instance.SetSelected(ObjectID);
            GameObject spawnObject = GameObject.Instantiate(ObjectPlacerManager.Instance.GetObjectByID(), this.transform);
            spawnObject.transform.position = position;
            spawnObject.SetActive(true);

            this.placedObjects.Add(spawnObject);
        }
		if (obj.Code == DELETE_ALL_EVENT) {
			this.DeleteAllObjects();
		}
    }

    /// <summary>
    /// Used for a user-defined target. The platform is oriented towards the camera for better viewing experience.
    /// </summary>
    public void FacetoCamera() {
        Quaternion originRot = this.transform.localRotation;
        this.transform.LookAt(this.arCamera.transform.localPosition + this.cameraOffset);

        originRot.x = this.transform.localRotation.x; //only update the X value after lookAt
        this.transform.localRotation = originRot;

        Debug.Log("Platform orientation updated!");
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = this.arCamera.ScreenPointToRay(Input.mousePosition);
			Debug.DrawRay (ray.origin, ray.direction, Color.red);

			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				Vector3 hitPos = hit.point;
				Debug.Log ("Hit pos: " + hitPos);

				GameObject spawnObject = GameObject.Instantiate (ObjectPlacerManager.Instance.GetObjectByID(), this.transform);
				spawnObject.transform.position = hitPos;
				spawnObject.SetActive (true);

				this.placedObjects.Add (spawnObject);
				sendObjectPlacedData(hitPos, ObjectPlacerManager.Instance.GetCurrentID());
			}
		}
	}

	private void sendObjectPlacedData(Vector3 position, int ObjectID)
	{
		object[] data=new object[] { position, ObjectID };
		Debug.Log("IAMSENDING");
		PhotonNetwork.RaiseEvent(OBJECT_PLACE_EVENT, data, RaiseEventOptions.Default, SendOptions.SendReliable);
	}


	private void OnShowAllObjects() {
		if (this.placedObjects.Count == 0) {
			return;
		}

		for(int i = 0; i < this.placedObjects.Count; i++) {
			this.placedObjects [i].SetActive (true);
		}
	}

	private void OnHideAllObjects() {
		if (this.placedObjects.Count == 0) {
			return;
		}

		for(int i = 0; i < this.placedObjects.Count; i++) {
			this.placedObjects [i].SetActive (false);
		}
	}

	private void DeleteAllObjects() {
		for(int i = 0; i < this.placedObjects.Count; i++) {
			GameObject.Destroy (this.placedObjects [i]);
		}

		this.placedObjects.Clear ();
		
	}

	private void OnDeleteAllClicked()
	{
		DeleteAllObjects();
        object data = null;
        PhotonNetwork.RaiseEvent(DELETE_ALL_EVENT, data, RaiseEventOptions.Default, SendOptions.SendReliable);
    }
}

