///<summary>
///Team Work for Game Development Project from MT Students
///Awais Khan, Cesar Quintero Arias, Hong Ma, Sebastian Ribecky
///Coded by Hong Ma
///Email: hong.ma@tu-ilmenau.de
///2019.01.31, TU Ilmenau, Germany
///</summary>
using UnityEngine;

/// <summary>
/// Start Game Button
/// </summary>
public class StartFightBtn : MonoBehaviour {

    public void loadNewSceneAttackFirst()
    {
        PhotonView view = GameObject.FindGameObjectWithTag("RemoteController").GetComponent<PhotonView>();
        ElementiaPlayer p1 = GameObject.FindGameObjectWithTag("PlayerOne").GetComponent<ElementiaPlayer>();

        // set which player is turn, and synchronize for  player two
        p1.IsMyTurn = true;

        // load new scene
        view.RPC("loadScene", PhotonTargets.All, "02_FightMenu");
    }
}
