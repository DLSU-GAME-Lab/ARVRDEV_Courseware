using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.Demo.Cockpit;
using TMPro;
using UnityEngine.UI;

public class RoomListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform content;
    [SerializeField]
    private RoomListing roomListing;
    [SerializeField]
    private Button CreateRoomButton;

    private List<RoomListing> roomListingList = new List<RoomListing>();

    //Updates the RoomListing for any Updates on the RoomList of the server.
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {

        Debug.Log("IgetListUpdates");
        //GameObject.Find("Status").GetComponent<TextMeshProUGUI>().text += "\nIGetListUpdates";

        foreach (RoomInfo info in roomList)
        {
            if (info.RemovedFromList)
            {
                int index = roomListingList.FindIndex(x => x.RoomInfo.Name==info.Name);
                if(index != -1)
                {
                    Destroy(roomListingList[index].gameObject);
                    roomListingList.RemoveAt(index);
                }
            }
            else
            {
                int index = roomListingList.FindIndex(x => x.RoomInfo.Name == info.Name);
                if (index == -1)
                {
                    RoomListing listing = RoomListing.Instantiate(roomListing, content);
                    if (listing != null)
                    {
                        listing.SetRoomInfo(info);
                        roomListingList.Add(listing);
                    }
                }
            }
            
        }
        if(roomListingList.Count > 0)
        {
            CreateRoomButton.interactable = false;
        }
    }

    //Destroys the RoomListings when joining a room.
    public override void OnJoinedLobby()
    {
        content.DestroyChildren();
        roomListingList.Clear();
    }

}
