using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.Demo.Cockpit;
using System;
using UnityEngine.UI;

public class PlayerListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform content;
    [SerializeField]
    private PlayerListing playerListing;
    [SerializeField]
    private Button StartGameButton;

    private List<PlayerListing> playerListingList = new List<PlayerListing>();

    public override void OnEnable()
    {
        base.OnEnable();
        if (!PhotonNetwork.IsConnected)
            return;
        if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players == null)
            return;


        
        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }

        if (PhotonNetwork.IsMasterClient)
        {
            StartGameButton.interactable = true;
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("someone else joined");
        AddPlayerListing(newPlayer);
    }

    public override void OnLeftRoom()
    {
        content.DestroyChildren();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = playerListingList.FindIndex(x => x.Player == otherPlayer);
        if (index != -1)
        {
            Destroy(playerListingList[index].gameObject);
            playerListingList.RemoveAt(index);
        }
    }

    private void AddPlayerListing(Player player)
    {
        PlayerListing listing = PlayerListing.Instantiate(playerListing, content);
        if (listing != null)
        {
            listing.SetPlayerInfo(player);
            playerListingList.Add(listing);
        }
    }

    public void OnClick_StartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.LoadLevel(1);
        }
    }


    

}
