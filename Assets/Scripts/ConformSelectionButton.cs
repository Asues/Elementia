///<summary>
///Team Work for Game Development Project from MT Students
///Awais Khan, Cesar Quintero Arias, Hong Ma, Sebastian Ribecky
///Coded by Hong Ma
///Email: hong.ma@tu-ilmenau.de
///2019.01.31, TU Ilmenau, Germany
///</summary>
using Vuforia;
using UnityEngine;

// conform to select a monster, the player will get the extra hp from this monster
public class ConformSelectionButton : MonoBehaviour {

    PhotonView view;
    ElementiaPlayer p1;
    public static ConformSelectionButton Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }

    void Start()
    {
        p1 = GameObject.FindGameObjectWithTag("PlayerOne").GetComponent<ElementiaPlayer>();
        view = GameObject.FindGameObjectWithTag("RemoteController").GetComponent<PhotonView>();
    }

    // To select monster function
    public void ConformSelectionBtnClicked()
    {
        // reduce the chose times
        p1.RemainingMonsters -= 1;
        // synchronize for player two
        view.RPC("ReduceMonsters", PhotonTargets.Others);

        // get monster from card
        TrackableBehaviour tr = GlobalValues.Instance.GetFirstTrackableImage();
        ElementiaMonster monster = GlobalValues.Instance.GetMonster(tr);

        // save the selected monster to attack monster
        p1.AttackMonster = monster;
        //synchronize
        view.RPC("ChangeMonsters", PhotonTargets.Others, monster.Name);

        // get extra hp from the selected monster
        p1.HP += monster.HP;
        p1.StartHp += monster.HP;
        // synchron
        view.RPC("ChangePlayerTwoHp", PhotonTargets.Others, p1.HP);
        view.RPC("ChangeStartHp", PhotonTargets.Others, p1.StartHp);

        // set player one this round is over
        FightMenuController.Instance.IsMyTurn = false;
        // synchron
        view.RPC("changePlayerRound", PhotonTargets.Others, true);

        FightMenuController.Instance.RefreshUI();

        // hide this conform button
        gameObject.SetActive(false);
    }
}
