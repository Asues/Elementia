///<summary>
///Team Work for Game Development Project from MT Students
///Awais Khan, Cesar Quintero Arias, Hong Ma, Sebastian Ribecky
///Coded by Hong Ma
///Email: hong.ma@tu-ilmenau.de
///2019.01.31, TU Ilmenau, Germany
///</summary>
using UnityEngine;
using UnityEngine.UI;

public class CoinTossBtn : MonoBehaviour
{
    public Button Coin;
    public static bool isRunning = false;
    public GameObject WinPanel, LosePanel;
    
    PhotonView view;
    bool playerOneWin;
    int rotationSpeed = 600;

    // Use this for initialization
    void Start ()
    {
        view = gameObject.GetComponent<PhotonView>();
        isRunning = false;
        // only alow one player to click the coin
        // who create the coin, who can click this coin
        if (view.isMine)
            Coin.onClick.AddListener(CoinTossBtnPressed);
    }

    void Update()
    {
        rotateCoinToss();
    }

    // player one clicked coin, and rotate the coin
    public void CoinTossBtnPressed()
    {
        if (view.isMine)
            isRunning = true;
    }

    // coin toss rotation
    void rotateCoinToss()
    {
        if (!isRunning)
            return;
        // if coin toss running
        if (rotationSpeed >=0) {
            Coin.transform.Rotate(0, -Time.deltaTime * rotationSpeed, 0);   //spin
            rotationSpeed -= 4;
        } 
        else  // if coin toss stopped
        {
            playerOneWin = (Random.value <= 0.5);   // random coin toss result
            isRunning = false;
            rotationSpeed = 0;
            Coin.transform.Rotate(0, 0, 0);
            Coin.transform.position.Set(0, 0, 0);
            Coin.transform.rotation.Set(0, 90, 90, 265);

            // onlye for test
            if(GlobalValues.Instance.TestModule)
                setPlayerCoinTossResult(true);
            else
                setPlayerCoinTossResult(playerOneWin);
        } 
    }

    /// <summary>
    /// According the random value to set which play choice first action
    /// </summary>
    /// <param name="val">Coin Toss Result</param>
    void setPlayerCoinTossResult(bool val)
    {
        // set player one coin toss result
        SelectMenuController.Instance.CoinTossWin = val;

        // set player two coin toss result
        PhotonView view = GameObject.FindGameObjectWithTag("RemoteController").GetComponent<PhotonView>();
        view.RPC("setCoinTossResult", PhotonTargets.Others, !val);
    }

    // remote function, create a coin at the center of the screen
    [PunRPC]
    void pinCoin()
    {
        GameObject coin = GameObject.FindGameObjectWithTag("CoinToss");
        if(coin != null)
            transform.SetParent(coin.transform);

        // if remove monster btn exsist, then deactivate the remove monster button
        GameObject removeBtn = GameObject.FindGameObjectWithTag("RemoveMonsterBtn");
        if (removeBtn)
            removeBtn.gameObject.SetActive(false);
    }
}
