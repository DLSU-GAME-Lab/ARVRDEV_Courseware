using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class WreckingBallTargetHandler : MonoBehaviour {

    [SerializeField] private GameObject wreckingBallObject;
    [SerializeField] private GameObject wbPlatform;

    private ObserverBehaviour observer;

	// Use this for initialization
	void Start () {
        this.wreckingBallObject.SetActive(false);

    }

    private void OnDestroy() {
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnTargetFound()
    {
        this.wreckingBallObject.SetActive(true);
        this.wbPlatform.SetActive(true);
    }

    public void OnTargetLost()
    {
        this.wreckingBallObject.SetActive(false);
        this.wbPlatform.SetActive(false);
    }
}
