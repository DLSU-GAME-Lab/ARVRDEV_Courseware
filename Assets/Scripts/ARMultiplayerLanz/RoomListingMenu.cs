using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.Demo.Cockpit;
using TMPro;

public class RoomListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform content;
    [SerializeField]
    private RoomListing roomListing;

    private List<RoomListing> roomListingList = new List<RoomListing>();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {

        Debug.Log("IgetListUpdates");
        GameObject.Find("Status").GetComponent<TextMeshProUGUI>().text += "\nIGetListUpdates";
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
                else
                {

                }
                
            }
            
        }

    }
    public override void OnJoinedLobby()
    {
        content.DestroyChildren();
        roomListingList.Clear();
    }

}
