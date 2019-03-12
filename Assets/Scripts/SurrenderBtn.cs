///<summary>
///Team Work for Game Development Project from MT Students
///Awais Khan, Cesar Quintero Arias, Hong Ma, Sebastian Ribecky
///Coded by Hong Ma
///Email: hong.ma@tu-ilmenau.de
///2019.01.31, TU Ilmenau, Germany
///</summary>using System.Collections;
using UnityEngine;

public class SurrenderBtn : MonoBehaviour {

    public GameObject PausePanel, WinPanel, LosePanel;

    public void SurrenderBtnClicked(){
        FightMenuController.Instance.SetGameOver(false);

        //synchronize
        PhotonView view = GameObject.FindGameObjectWithTag("RemoteController").GetComponent<PhotonView>();
        view.RPC("SetGameOver", PhotonTargets.Others, true);
    }
}
