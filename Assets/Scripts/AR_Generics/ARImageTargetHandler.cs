using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

/// <summary>
/// Handles general AR image tracking logic, mimicking the behavior of Vuforia's ImageTargetHandler.
/// </summary>
public class ARImageTargetHandler : MonoBehaviour
{
    [SerializeField] ARTrackedImageManager arTrackedImageManager;
    [SerializeField] GameObject[] arObjectsToActivate; //sequential order of AR objects to activate, based on image target
    [SerializeField] string[] imageTargetNames; //refers to the names of the image targets in the reference image library

    private Dictionary<string, GameObject> arObjectsDict = new Dictionary<string, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        this.arTrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;

        for (int i = 0; i < this.arObjectsToActivate.Length; i++)
        {
            this.arObjectsDict.Add(this.imageTargetNames[i], this.arObjectsToActivate[i]);
            this.arObjectsToActivate[i].SetActive(false);
        }
    }

    void OnDestroy()
    {
        this.arTrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {

        for (int i = 0; i < args.added.Count; i++)
        {
            if (this.arObjectsDict.ContainsKey(args.added[i].referenceImage.name))
            {
                GameObject arObject = this.arObjectsDict[args.added[i].referenceImage.name];
                arObject.transform.localPosition = args.added[i].transform.position;
                arObject.transform.localRotation = args.added[i].transform.rotation;
                arObject.SetActive(true);
            }
        }

        // for (int i = 0; i < args.updated.Count; i++)
        // {
        //     if (this.arObjectsDict.ContainsKey(args.updated[i].referenceImage.name))
        //     {
        //         GameObject arObject = this.arObjectsDict[args.updated[i].referenceImage.name];
        //         arObject.transform.localPosition = args.updated[i].transform.position;
        //         arObject.transform.localRotation = args.updated[i].transform.rotation;
        //         arObject.SetActive(true);
        //     }
        // }

        for (int i = 0; i < args.removed.Count; i++)
        {
            if (this.arObjectsDict.ContainsKey(args.removed[i].referenceImage.name))
            {
                this.arObjectsDict[args.removed[i].referenceImage.name].SetActive(false);
            }
        }
    }
}
