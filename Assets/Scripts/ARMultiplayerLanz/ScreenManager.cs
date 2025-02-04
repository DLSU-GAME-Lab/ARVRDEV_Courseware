using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    GameObject RoomScreen;
    [SerializeField]
    GameObject LobbyScreen;
    [SerializeField]
    GameObject NameScreen;
    [SerializeField]
    private TextMeshProUGUI playerName;
    //Changes the UI from lobby screen to Room Screen on joining a room
    public override void OnJoinedRoom()
    {
        RoomScreen.SetActive(true);
        LobbyScreen.SetActive(false);
    }
    // Changes the UI from Room Screen to Lobby Screen on leaving a room
    public override void OnLeftRoom()
    {
        RoomScreen.SetActive(false);
        LobbyScreen.SetActive(true);
    }
    // Changes the UI from Name setting screen to Lobby Screen
    public void OnClickSetName()
    {
        PhotonNetwork.NickName=playerName.text;
        NameScreen.SetActive(false);
        LobbyScreen.SetActive(true);

    }
}
