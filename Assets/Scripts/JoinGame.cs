///<summary>
///Team Work for Game Development Project from MT Students
///Awais Khan, Cesar Quintero Arias, Hong Ma, Sebastian Ribecky
///Coded by Hong Ma
///Email: hong.ma@tu-ilmenau.de
///2019.01.31, TU Ilmenau, Germany
///</summary>
using UnityEngine;
using System.Collections;

/// <summary>
/// At Game Start, player should connet to Photon Server
/// Create Game Room and Lobby
/// </summary>
public class JoinGame : MonoBehaviour {

    byte maxPlayers = 2;
    string m_GameVersion = "v1.0";
    string m_Prefabs = "ElementiaPlayer";
   
    // Use this for initialization
    void Start()
    {
        PhotonNetwork.automaticallySyncScene = false;

        // connect to server
        PhotonNetwork.ConnectUsingSettings(m_GameVersion); 
    }

    void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    void OnJoinedLobby()
    {
        RoomOptions op = new RoomOptions();
        op.MaxPlayers = maxPlayers;
        PhotonNetwork.JoinOrCreateRoom("Room", op, TypedLobby.Default);
    }

    void OnJoinedRoom()
    {
        // create the player
        if (PhotonNetwork.playerList.Length == 1)
            StartCoroutine(SpwanPlayer());
        else if (PhotonNetwork.playerList.Length == 2)
            StartCoroutine(SpwanPlayer2());
    }

    IEnumerator SpwanPlayer()
    {
        yield return new WaitForSeconds(1);
        PhotonNetwork.Instantiate(m_Prefabs, Vector3.left, Quaternion.identity, 0);
    }

    IEnumerator SpwanPlayer2()
    {
        yield return new WaitForSeconds(1);
        PhotonNetwork.Instantiate(m_Prefabs, Vector3.left, Quaternion.identity, 0);
    }
}
