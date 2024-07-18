using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    GameObject RoomScreen;
    [SerializeField]
    GameObject LobbyScreen;

    // Start is called before the first frame update
    public override void OnJoinedRoom()
    {
        RoomScreen.SetActive(true);
        LobbyScreen.SetActive(false);
    }

    public override void OnLeftRoom()
    {
        RoomScreen.SetActive(false);
        LobbyScreen.SetActive(true);
    }
}
