///<summary>
///Team Work for Game Development Project from MT Students
///Awais Khan, Cesar Quintero Arias, Hong Ma, Sebastian Ribecky
///Coded by Hong Ma
///Email: hong.ma@tu-ilmenau.de
///2019.01.31, TU Ilmenau, Germany
///</summary>
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Game Controller for Start Men
/// </summary>
public class StartMenuController : MonoBehaviour {

    /// <summary>
    /// only both player hase joined the game that can start the game, to avoid the player has already select monster and the other is not joind the game
    /// </summary>
    public void StartBtnPressed()
    {
        if(PhotonNetwork.otherPlayers.Length > 0)
            SceneManager.LoadScene("01_SelectMonsterMenu");
    }
}
