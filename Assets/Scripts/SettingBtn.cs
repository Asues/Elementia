///<summary>
///Team Work for Game Development Project from MT Students
///Awais Khan, Cesar Quintero Arias, Hong Ma, Sebastian Ribecky
///Coded by Hong Ma
///Email: hong.ma@tu-ilmenau.de
///2019.01.31, TU Ilmenau, Germany
///</summary>
using UnityEngine;

/// <summary>
/// Show or hide the setting menu
/// </summary>
public class SettingBtn : MonoBehaviour {

    public GameObject SettingPanel;

    public void ShowPausePanel(){
        SettingPanel.gameObject.SetActive(!SettingPanel.gameObject.activeSelf);
    }
}
