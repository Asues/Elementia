///<summary>
///Team Work for Game Development Project from MT Students
///Awais Khan, Cesar Quintero Arias, Hong Ma, Sebastian Ribecky
///Coded by Hong Ma
///Email: hong.ma@tu-ilmenau.de
///2019.01.31, TU Ilmenau, Germany
///</summary>
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Remote function, to run the function for another player through Photon Network Framworks
/// </summary>
public class RemoteFunctions : MonoBehaviour {

    ElementiaPlayer p1, p2;

    private void Start()
    {
        p1 = GameObject.FindGameObjectWithTag("PlayerOne").GetComponent<ElementiaPlayer>();
        p2 = GameObject.FindGameObjectWithTag("PlayerTwo").GetComponent<ElementiaPlayer>();
    }

    [PunRPC]
    void addMonsterForPlayerTwo(string name)
    {
        ElementiaMonster monster = GlobalValues.Instance.GetMonster(name);
        p2.Monsters.Add(monster);
    }

    [PunRPC]
    void removeMonsterForPlayerTwo()
    {
        p2.Monsters.RemoveAt(p2.Monsters.Count - 1);
    }

    [PunRPC]
    void playAttackAnimation(string name)
    {
        Animator ani = GameObject.FindGameObjectWithTag(name).GetComponent<Animator>();
        ani.Play("Attack");
    }

    [PunRPC]
    void playHitAnimation(string name)
    {
        Animator ani = GameObject.FindGameObjectWithTag(name).GetComponent<Animator>();
        ani.Play("Hit");
    }

    [PunRPC]
    void playDieAnimation(string name)
    {
        Animator ani = GameObject.FindGameObjectWithTag(name).GetComponent<Animator>();
        ani.Play("Die");
    }


    /// <summary>
    /// after coin toss, will show or hide the win/lose pannel
    /// </summary>
    /// <param name="winOrLose">if true, will show coin toss pannel</param>
    [PunRPC]
    void showPanel(bool winOrLose)
    {
        GameObject coinTossWinPanel = transform.Find("Canvas").Find("CoinTossWinPanel").gameObject;
        GameObject coinTossLosePanel = transform.Find("Canvas").Find("CoinTossLosePanel").gameObject;
        GameObject coin = GameObject.FindGameObjectWithTag("CoinTossBtn");
        if (!coin)
            return;

        coinTossWinPanel.SetActive(winOrLose);
        coinTossLosePanel.SetActive(!winOrLose);
        Destroy(coin);
    }


    [PunRPC]
    void loadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    [PunRPC]
    void setCoinTossResult(bool val)
    {
        SelectMenuController.Instance.CoinTossWin = val;
    }

    // change  player two HP (remote)
    [PunRPC]
    void reducePlayerOneHp(int value)
    {
        p1.HP -= value;
        if (p1.HP <= 0)
        {
            p1.HP = 0;
            FightMenuController.Instance.SetGameOver(false);
        }

        // change UI elements, like HP
        Image p1HealthBar = GameObject.FindGameObjectWithTag("PlayerOneHealthBar").GetComponent<Image>();
        Text p1HealthText = GameObject.FindGameObjectWithTag("PlayerOneHealthTxt").GetComponent<Text>();
        p1HealthBar.fillAmount = p1.HP / (float)p1.StartHp;
        p1HealthText.text = "You: " + p1.HP;
    }


    [PunRPC]
    void ChangePlayerTwoHp(int value)
    {
        p2.HP = value;
        FightMenuController.Instance.RefreshUI();
    }

    [PunRPC]
    void changePlayerRound(bool val)
    {
        FightMenuController.Instance.IsMyTurn = val;
    }

    [PunRPC]
    void ChangeMonsters(string name)
    {
        ElementiaMonster monster = GlobalValues.Instance.GetMonster(name);
        p2.AttackMonster = monster;
    }

    [PunRPC]
    void ChangeStartHp(int val)
    {
        p2.StartHp = val;
    }

    [PunRPC]
    void ChangeStartMonsters(string name)
    {
        ElementiaMonster monster = GlobalValues.Instance.GetMonster(name);
        p2.Monsters[0] = monster;
    }

    [PunRPC]    // float attack value on monter two
    void floatAttackValue(string val)
    {
        FloatingTextController.CreateFloatingText(p1.AttackMonster, val);
    }

    // remote function to show or hide the menu
    [PunRPC]
    void setSettingPanelActive(bool val)
    {
        SettingMenuController.Instance.SetSettingPanelActive(val);
    }

    [PunRPC] // reduce the changing monster times
    void ReduceMonsters()
    {
        p2.RemainingMonsters -= 1;
        FightMenuController.Instance.RefreshUI();
    }

    [PunRPC] // reduce the changing monster times
    void SetRemainingMonsterForPlayerTwo(int val)
    {
        p2.RemainingMonsters = val;
        FightMenuController.Instance.RefreshUI();
    }

    [PunRPC]
    void SetGameOver(bool val)
    {
        FightMenuController.Instance.SetGameOver(val);
    }
}
