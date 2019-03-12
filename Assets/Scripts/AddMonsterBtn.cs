///<summary>
///Team Work for Game Development Project from MT Students
///Awais Khan, Cesar Quintero Arias, Hong Ma, Sebastian Ribecky
///Coded by Hong Ma
///Email: hong.ma@tu-ilmenau.de
///2019.01.31, TU Ilmenau, Germany
///</summary>
using UnityEngine;
using Vuforia;

public class AddMonsterBtn : MonoBehaviour {

    public void AddMonsterBtnPressed()
    {
        // get monster
        TrackableBehaviour tb;
        tb = GlobalValues.Instance.GetFirstTrackableImage();
        ElementiaMonster monster = GlobalValues.Instance.GetMonster(tb);

        // add monster for p1
        ElementiaPlayer p1 = GameObject.FindGameObjectWithTag("PlayerOne").GetComponent<ElementiaPlayer>();
        p1.Monsters.Add(monster);

        // synchronize p1 selected monster for p2
        PhotonView view = GameObject.FindGameObjectWithTag("RemoteController").GetComponent<PhotonView>();
        view.RPC("addMonsterForPlayerTwo", PhotonTargets.Others, monster.Name);

        // Change the above information content, to shwo how many monster did player already seledted 
        ElementiaPlayer p2 = GameObject.FindGameObjectWithTag("PlayerTwo").GetComponent<ElementiaPlayer>();
        SelectMenuController.Instance.ChangeInformation(p1, p2);

        // show or hide add/remove monster btn
        SelectMenuController.Instance.SetBtnStatus();
    }
}