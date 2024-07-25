using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestConnect : MonoBehaviourPunCallbacks
{
    [SerializeField]
    RawImage ConnectionStatus;
    [SerializeField]
    Button SetNameButton;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Conneting to server");
        PhotonNetwork.AutomaticallySyncScene=true;
        PhotonNetwork.NickName = "honk";
        PhotonNetwork.GameVersion = "0.0.1";
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Server");
        //GameObject.Find("Status").GetComponent<TextMeshProUGUI>().text+="Connected to Server";
        if(!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby();
        ConnectionStatus.color = Color.green;
        SetNameButton.interactable = true;
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log(cause);
    }
}
