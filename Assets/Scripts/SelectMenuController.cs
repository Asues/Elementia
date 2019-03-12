///<summary>
///Team Work for Game Development Project from MT Students
///Awais Khan, Cesar Quintero Arias, Hong Ma, Sebastian Ribecky
///Coded by Hong Ma
///Email: hong.ma@tu-ilmenau.de
///2019.01.31, TU Ilmenau, Germany
///</summary>
using UnityEngine;
using UnityEngine.UI;

public class SelectMenuController : MonoBehaviour {

    ElementiaPlayer p1, p2;
    public Text InfoText;
    public Button AddBtn, RemoveBtn;
    public static SelectMenuController Instance;
    public GameObject CoinTossWinPanel, CoinTossLosePanel;

    // if coin finish the rotation, i will random a value, if win, the player will have a change, 
    // to decide weahter to figth first or change his monster
    public bool CoinTossWin
    {
        set
        {
            if(value==true) // coin toss win, show win panel
            {
                CoinTossWinPanel.SetActive(true);
                CoinTossLosePanel.SetActive(false);
            }
            else // coin toss lose, show lose panel
            {
                CoinTossWinPanel.SetActive(false);
                CoinTossLosePanel.SetActive(true);
            }
            destroyCoinTossBtn();
        }
    }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }

    void Start () {
        p1 = GameObject.FindGameObjectWithTag("PlayerOne").GetComponent<ElementiaPlayer>();
        p2 = GameObject.FindGameObjectWithTag("PlayerTwo").GetComponent<ElementiaPlayer>();

        AddBtn.gameObject.SetActive(true);
        RemoveBtn.gameObject.SetActive(false);

        CoinTossWinPanel.SetActive(false);
        CoinTossLosePanel.SetActive(false);
    }

    void destroyCoinTossBtn()
    {
        GameObject coinToss = GameObject.FindGameObjectWithTag("CoinTossBtn");
        if (coinToss != null)
            Destroy(coinToss);
    }

    // create a coin in the middle of the creen
    void createCoinTossBtn()
    {
        // coin prefabs is in the "Photon Unity Networking/Resources"
        GameObject coin = GameObject.FindGameObjectWithTag("CoinTossBtn");
        if (coin != null)
        {
            Destroy(coin); // if exist, destroy
            return;
        }
            
        // find coin parent object, like a anchor, and create a coin toss button
        GameObject coinToss = GameObject.FindGameObjectWithTag("CoinToss");
        GameObject visualizer = PhotonNetwork.Instantiate("CoinTossBtn", coinToss.transform.position, Quaternion.identity, 0);
        visualizer.transform.SetParent(coinToss.transform);

        PhotonView view = visualizer.GetComponent<PhotonView>();
        if (view.isMine)
        {
            // pin the coin to the canvas, this function is in the file "coinTossBt.cs"
            view.RPC("pinCoin", PhotonTargets.Others, null);
        }
    }

    /// <summary>
    /// According the player selected monsters to show or hide the add/remove button
    /// </summary>
    public void SetBtnStatus()
    {
        if (p1.Monsters.Count < 3)
            AddBtn.gameObject.SetActive(true);
        else
            AddBtn.gameObject.SetActive(false);

        if (p1.Monsters.Count > 0)
            RemoveBtn.gameObject.SetActive(true);
        else
            RemoveBtn.gameObject.SetActive(false);

        if (p1.Monsters.Count == 3 && p2.Monsters.Count == 3)
        {
            AddBtn.gameObject.SetActive(false);
            RemoveBtn.gameObject.SetActive(false);
            // don't show monsters, when player see the coin
            // If the player has already choose 3 monsters, then will deactivate to show monster on the card
            GameObject monsters = GameObject.FindGameObjectWithTag("Monsters");
            monsters.gameObject.SetActive(false);
            createCoinTossBtn();
        }
    }

    /// <summary>
    /// Change the above information content, to shwo how many monster did player already seledted
    /// </summary>
    /// <param name="p1">Player One</param>
    public void ChangeInformation(ElementiaPlayer p1, ElementiaPlayer p2)
    {
        switch (p1.Monsters.Count)
        {
            case 0:
                InfoText.text = "Select Starting Monster";
                break;
            case 1:
                InfoText.text = "Select Monster Two";
                break;
            case 2:
                InfoText.text = "Select Monster Three";
                break;
            case 3:
                if(p2.Monsters.Count == 3)
                    InfoText.text = "Press Coin to Start";
                else
                    InfoText.text = "Please waiting for Opponent to select monsters";
                break;
            default:
                break;
        }
    }
}
