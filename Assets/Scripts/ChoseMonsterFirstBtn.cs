///<summary>
///Team Work for Game Development Project from MT Students
///Awais Khan, Cesar Quintero Arias, Hong Ma, Sebastian Ribecky
///Coded by Hong Ma
///Email: hong.ma@tu-ilmenau.de
///2019.01.31, TU Ilmenau, Germany
///</summary>
using UnityEngine;

public class ChoseMonsterFirstBtn : MonoBehaviour {

    /// <summary>
    /// the player hase choice selecte monster, not attack first
    /// </summary>
    public void chooseMonsterFirstBtnClicked(){
        // get player one and phton view
        ElementiaPlayer p1 = GameObject.FindGameObjectWithTag("PlayerOne").GetComponent<ElementiaPlayer>();
        PhotonView view = GameObject.FindGameObjectWithTag("RemoteController").GetComponent<PhotonView>();

        p1.IsChangingMonster = true;
        p1.Monsters[0] = new ElementiaDemoMonster();  // if select monster first, will don't get extra hp
        p1.AttackMonster = p1.Monsters[0];
        //synchronize
        view.RPC("ChangeStartMonsters", PhotonTargets.Others, p1.AttackMonster.Name);

        // extra one exchange monsters
        p1.RemainingMonsters = 3;
        // synchronize
        view.RPC("SetRemainingMonsterForPlayerTwo", PhotonTargets.Others, p1.RemainingMonsters);
        
        // set which player is turn
        p1.IsMyTurn = true;

        // load new scene
        view.RPC("loadScene", PhotonTargets.All, "02_FightMenu");
    }
}
