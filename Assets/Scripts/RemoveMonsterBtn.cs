///<summary>
///Team Work for Game Development Project from MT Students
///Awais Khan, Cesar Quintero Arias, Hong Ma, Sebastian Ribecky
///Coded by Hong Ma
///Email: hong.ma@tu-ilmenau.de
///2019.01.31, TU Ilmenau, Germany
///</summary>
using Vuforia;
using UnityEngine;

/// <summary>
/// Remove player selected previous monster
/// </summary>
public class RemoveMonsterBtn : MonoBehaviour {

    // make sure there is only one coin to be created
    void DestroyCoinTossBtn()
    {
        GameObject coinToss = GameObject.FindGameObjectWithTag("CoinTossBtn");
        if(coinToss != null)
            Destroy(coinToss);
    }

    // remove previous monster
    public void RemoveMonsterBtnPressed()
    {
        DestroyCoinTossBtn();

        ElementiaPlayer p1 = GameObject.FindGameObjectWithTag("PlayerOne").GetComponent<ElementiaPlayer>();
        ElementiaPlayer p2 = GameObject.FindGameObjectWithTag("PlayerTwo").GetComponent<ElementiaPlayer>();
        PhotonView view = GameObject.FindGameObjectWithTag("RemoteController").GetComponent<PhotonView>();

        p1.Monsters.RemoveAt(p1.Monsters.Count - 1);
        // synchronize
        view.RPC("removeMonsterForPlayerTwo", PhotonTargets.Others);

        // Change the above information content, to shwo how many monster did player already seledted
        SelectMenuController.Instance.ChangeInformation(p1, p2);

        // show or hide add/remove monster btn
        SelectMenuController.Instance.SetBtnStatus();
    }
}
