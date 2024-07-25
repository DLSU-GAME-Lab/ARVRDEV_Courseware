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

    public void OnClickSetName()
    {
        PhotonNetwork.NickName=playerName.text;
        NameScreen.SetActive(false);
        LobbyScreen.SetActive(true);

    }
}
