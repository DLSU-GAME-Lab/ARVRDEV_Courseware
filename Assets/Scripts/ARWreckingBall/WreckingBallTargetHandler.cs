using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class WreckingBallTargetHandler : MonoBehaviour {

    [SerializeField] private GameObject wreckingBallObject;
    [SerializeField] private GameObject wbPlatform;

    private GameObject wbInstance;
    private ObserverBehaviour observer;
    private Vector3 wbOrigPosition;

	// Use this for initialization
	void Start () { 
       this.wbOrigPosition = this.wreckingBallObject.transform.localPosition;
       this.OnTargetLost();
    }

    private void OnDestroy() {
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnTargetFound()
    {
        //reset the wrecking ball position by re-instantiating the object
        this.wbInstance = GameObject.Instantiate(this.wreckingBallObject, this.wreckingBallObject.transform.parent);
        this.wbInstance.transform.localPosition = this.wbOrigPosition;
        this.wbInstance.SetActive(true);

        this.wbPlatform.SetActive(true);
    }

    public void OnTargetLost()
    {
        this.wreckingBallObject.SetActive(false);
        this.wbPlatform.SetActive(false);

        if (this.wbInstance != null)
        {
            GameObject.Destroy(this.wbInstance);
        }
    }
}
