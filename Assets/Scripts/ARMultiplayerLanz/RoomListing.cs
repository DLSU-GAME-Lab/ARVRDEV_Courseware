using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;
using Photon.Pun;

public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    public RoomInfo RoomInfo { get; private set; }

    // Function for RoomListingMenu Script to set the name of newly instantiated RoomListings
    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;
        text.text=roomInfo.MaxPlayers+", "+roomInfo.Name;
    }
    // Function to join the room that was clicked in the lobby.
    public void OnClick_Button()
    {
        PhotonNetwork.JoinRoom(RoomInfo.Name);
    }
}
