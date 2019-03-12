///<summary>
///Team Work for Game Development Project from MT Students
///Awais Khan, Cesar Quintero Arias, Hong Ma, Sebastian Ribecky
///Coded by Hong Ma
///Email: hong.ma@tu-ilmenau.de
///2019.01.31, TU Ilmenau, Germany
///</summary>
using UnityEngine;
using UnityEngine.UI;

public class FightMenuController : MonoBehaviour {

    PhotonView view;
    ElementiaPlayer p1, p2;

    // public instance
    public static FightMenuController Instance;

    // Information Panel
    public Image PlayerOneHealthBar, PlayerTwoHealthBar;
    public Text InformationText;    // the alert information in the middle of the top of screen
    public Text PlayerOneHealthText, PlayerTwoHealthText;
    public Text PlayerOneRemainingMonstersText, PlayerTwoRemainingMonstersText;

    // Fight result Panel
    public GameObject WinPanel, LosePanel, SettingPanel;

    // buttons
    public Button AttackBtn, ChangeMonsterBtn, ConformChangeMonsterBtn;

    // decide whether this round belongs to player
    public bool IsMyTurn
    {
        set
        {
            if (value == true)
            {
                p1.IsMyTurn = true;
                InformationText.text = "Your Turn";
                AttackBtn.gameObject.SetActive(true);   // only player's round will show the attack/change monster buttons
                ChangeMonsterBtn.gameObject.SetActive(p1.RemainingMonsters > 0);
            }
            else
            {
                p1.IsMyTurn = false;
                InformationText.text = "Waiting for Opponent";
                AttackBtn.gameObject.SetActive(false);
                ChangeMonsterBtn.gameObject.SetActive(false);
            }
        }
        get
        {
            return p1.IsMyTurn;
        }
    }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }

    // reset UI elements
    void Start()
    {
        p1 = GameObject.FindGameObjectWithTag("PlayerOne").GetComponent<ElementiaPlayer>();
        p2 = GameObject.FindGameObjectWithTag("PlayerTwo").GetComponent<ElementiaPlayer>();
        view = GameObject.FindGameObjectWithTag("RemoteController").GetComponent<PhotonView>();

        IsMyTurn = p1.IsMyTurn;

        // show monsters
        GameObject monsters = GameObject.FindGameObjectWithTag("MonsterRoot").transform.Find("Monsters").gameObject;
        monsters.SetActive(true);

        InformationText.text = "";

        p1.AttackMonster = p1.Monsters[0];
        p2.AttackMonster = p2.Monsters[0];

        // calculate the start hp, if p1 pick monster first, he can't get monster hp at first
        if (p1.IsChangingMonster)
        {
            AttackBtn.gameObject.SetActive(false);
            ChangeMonsterBtn.gameObject.SetActive(false);
            ConformChangeMonsterBtn.gameObject.SetActive(true);
        }
        else // if pick monster fist, deactivate the attack/change monster button, and show the selecton button
        {
            p1.HP += p1.AttackMonster.HP;
            AttackBtn.gameObject.SetActive(IsMyTurn);
            ChangeMonsterBtn.gameObject.SetActive(IsMyTurn && (p1.RemainingMonsters>0));
            ConformChangeMonsterBtn.gameObject.SetActive(false);
        }
        p2.HP += p2.AttackMonster.HP;

        p1.StartHp = p1.HP;
        p2.StartHp = p2.HP;
        RefreshUI();
    }

    // change the UI informations
    public void RefreshUI()
    {
        PlayerOneHealthText.text = "You: " + p1.HP;
        PlayerTwoHealthText.text = "Opponent: " + p2.HP;
        PlayerOneHealthBar.fillAmount = p1.HP / (float)p1.StartHp;
        PlayerTwoHealthBar.fillAmount = p2.HP / (float)p2.StartHp;
        PlayerOneRemainingMonstersText.text = "Remaining Monsters: " + p1.RemainingMonsters.ToString();
        PlayerTwoRemainingMonstersText.text = "Remaining Monsters: " + p2.RemainingMonsters.ToString();
    }

    /// <summary>
    /// Reduce the player hp
    /// </summary>
    /// <param name="value"></param>
    public void reducePlayerTwoHp(int value)
    {
        p2.HP -= value;
        if (p2.HP <= 0)
        {
            p2.HP = 0;
            SetGameOver(true);  // you (p1) win the game
        }
        RefreshUI();
    }

    /// <summary>
    /// Set the game finish
    /// </summary>
    /// <param name="isP1Win">whether player has win the game</param>
    public void SetGameOver(bool isP1Win)
    {
        // disable pause menu
        SettingPanel.gameObject.SetActive(false);

        if (isP1Win == true) // u win, he lose
        {
            // deactivate the buttons
            WinPanel.gameObject.SetActive(true);
            LosePanel.gameObject.SetActive(false);

            // set hp bar and hp
            p2.HP = 0;
            PlayerTwoHealthBar.fillAmount = 0;

            // play die animation
            view.RPC("playDieAnimation", PhotonTargets.All, p2.AttackMonster.Name);
        }
        else
        {
            WinPanel.gameObject.SetActive(false);
            LosePanel.gameObject.SetActive(true);
            p1.HP = 0;
            PlayerOneHealthBar.fillAmount = 0;
            view.RPC("playDieAnimation", PhotonTargets.All, p1.AttackMonster.Name);
        }
        // deactivate the fight and change monster buttons
        AttackBtn.gameObject.SetActive(false);
        ChangeMonsterBtn.gameObject.SetActive(false);
    }

    private bool m_IsChangingMonster = false;
    /// <summary>
    /// Trigger, whether the player is changing monster
    /// </summary>
    public bool IsChangingMonster
    {
        get { return m_IsChangingMonster; }
        set
        {
            m_IsChangingMonster = value;
            GameObject changeMonsterBtn = transform.Find("Canvas").Find("ChangeMonsterBtn").gameObject;
            changeMonsterBtn.gameObject.SetActive(value);
            PhotonView view = gameObject.GetComponent<PhotonView>();
            view.RPC("setChangingMonster", PhotonTargets.Others, m_IsChangingMonster);
        }
    }
}



