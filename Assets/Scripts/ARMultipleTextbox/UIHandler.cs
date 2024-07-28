using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
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
        EventBroadcaster.Instance.PostEvent(EventNames.ARMultipleTextbox.ON_CLOSE_TEXTBOX);
        this.gameObject.SetActive(false);
    }

    public void OnShowHints()
    {
        EventBroadcaster.Instance.PostEvent(EventNames.ARMultipleTextbox.ON_SHOW_HINTS); 
    }

    public void OnTextboxClose()
    {
        Debug.Log("Detected Click on " + gameObject.name);
        EventBroadcaster.Instance.PostEvent(EventNames.ARMultipleTextbox.ON_CLOSE_TEXTBOX);
    }
}
