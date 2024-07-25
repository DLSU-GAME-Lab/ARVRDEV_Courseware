using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshProUGUI roomName;
    
    public void onClick_CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
            return;
        PhotonNetwork.GetCustomRoomList(PhotonNetwork.NetworkingClient.CurrentLobby, "*");
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 8;
        Debug.Log(roomName.text);
        PhotonNetwork.CreateRoom(roomName.text, options);
    }

    public override void OnCreatedRoom()
    {

    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room Creation Failed" + message+returnCode);
    }

}
