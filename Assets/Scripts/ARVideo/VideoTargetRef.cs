using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VideoTargetRef : MonoBehaviour {

    // Use this for initialization
    void Start () {
        
	}

    // Update is called once per frame
    void Update () {
		
	}


    public void OnTargetFound()
    {
        VideoSizeComputer.Instance.OnDetected(this);
    }
}
