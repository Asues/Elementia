///<summary>
///Team Work for Game Development Project from MT Students
///Awais Khan, Cesar Quintero Arias, Hong Ma, Sebastian Ribecky
///Coded by Hong Ma
///Email: hong.ma@tu-ilmenau.de
///2019.01.31, TU Ilmenau, Germany
///</summary>
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Show or hide the Setting Pannel
/// </summary>
public class SettingMenuController : MonoBehaviour {

    public Text PauseBtnTxt;
    public GameObject SettingMenu;
    public static SettingMenuController Instance;

    private bool m_IsGamePause = false;
    // trigger, if true, show pause menu
    public bool IsGamePause
    {
        get { return m_IsGamePause; }
        set
        {
            // synchronize for all players, they will both get setting panel
            PhotonView view = GameObject.FindGameObjectWithTag("RemoteController").GetComponent<PhotonView>();
            view.RPC("setSettingPanelActive", PhotonTargets.All, value);
        }
    }

    /// <summary>
    /// Set or hid the setting panel
    /// </summary>
    /// <param name="val">if true, show setting panel</param>
    public void SetSettingPanelActive(bool val)
    {
        m_IsGamePause = val;
        if (val)
            PauseBtnTxt.text = "Resume";
        else
            PauseBtnTxt.text = "Pause";
        SettingMenu.SetActive(val);
    }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }

}
