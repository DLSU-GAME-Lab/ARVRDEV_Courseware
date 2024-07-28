using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArBroadcast : MonoBehaviour
{

    public GameObject MazePrefab;
    private GameObject MazeReference;
    private void Start()
    {

    }
    // Start is called before the first frame update
    public void BroadcastPlatformFound()
    {
        EventBroadcaster.Instance.PostEvent(EventNames.ARPathFindEvents.ON_PLATFORM_DETECTED);
        Invoke("InstantiateMaze", 0.1f);
    }

    public void BroadcastPlatformLost()
    {
        EventBroadcaster.Instance.PostEvent(EventNames.ARPathFindEvents.ON_PLATFORM_HIDDEN);
        DestroyMaze(); 
    }

    public void BroadcastBeaconFound()
    {
        Debug.Log("Func called");
        EventBroadcaster.Instance.PostEvent(EventNames.ARPathFindEvents.ON_BEACON_DETECTED);
    }

    private void InstantiateMaze()
    {
        MazeReference= Instantiate(MazePrefab, this.transform);
    }

    private void DestroyMaze()
    {
        Debug.Log("Destory");
        Debug.Log(MazeReference.name);
        Destroy(MazeReference);
        MazeReference = null;
    }
}
