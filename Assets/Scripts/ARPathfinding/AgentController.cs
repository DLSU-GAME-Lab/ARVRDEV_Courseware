using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private AICharacterControl[] aiAgents;
    // Start is called before the first frame update
    void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.ARPathFindEvents.ON_PLATFORM_DETECTED, this.OnPlatformDetected);
        EventBroadcaster.Instance.AddObserver(EventNames.ARPathFindEvents.ON_PLATFORM_HIDDEN, this.OnPlatformHidden);
        EventBroadcaster.Instance.AddObserver(EventNames.ARPathFindEvents.ON_BEACON_DETECTED, this.OnBeaconDetected);

    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveActionAtObserver(EventNames.ARPathFindEvents.ON_PLATFORM_DETECTED, this.OnPlatformDetected);
        EventBroadcaster.Instance.RemoveActionAtObserver(EventNames.ARPathFindEvents.ON_PLATFORM_HIDDEN, this.OnPlatformHidden);
        EventBroadcaster.Instance.RemoveActionAtObserver(EventNames.ARPathFindEvents.ON_BEACON_DETECTED, this.OnBeaconDetected);
    }

    private void OnPlatformDetected()
    {
        this.SetAgentsActive(true);
    }

    private void OnPlatformHidden()
    {
        this.SetAgentsActive(false);
    }

    private void OnBeaconDetected(Parameters parameters)
    {
        Vector3 target = (Vector3)parameters.GetObjectExtra(BeaconTarget.BEACON_POSITION_KEY);
        this.MoveAllAgents(target);
    }

    private void MoveAllAgents(Vector3 target)
    {
        for(int i =0; i< this.aiAgents.Length; i++)
        {
            this.aiAgents[i].SetDestination(target);

            InfoScreen infoScreen = (InfoScreen) ViewHandler.Instance.FindActiveView(ViewNames.INFO_SCREEN_NAME);
            infoScreen.SetMessage("Set agents to position: " + target.ToString());
        }
        
    }

    public void SetAgentsActive(bool active)
    {
        for (int i = 0; i< this.aiAgents.Length;i++)
        {
            this.aiAgents[i].gameObject.SetActive(active);
        }
    }
}
