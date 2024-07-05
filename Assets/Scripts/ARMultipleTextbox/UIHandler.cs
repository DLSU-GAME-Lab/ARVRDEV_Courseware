using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTargetFound()
    {
        this.gameObject.SetActive(true);
    }

    public void OnTargetLost()
    {
        this.gameObject.SetActive(false);
    }

    public void OnShowHints()
    {
        EventBroadcaster.Instance.PostEvent(EventNames.ARMultipleTextbox.ON_SHOW_HINTS); 
    }
}
