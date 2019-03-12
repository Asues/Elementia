///<summary>
///Team Work for Game Development Project from MT Students
///Awais Khan, Cesar Quintero Arias, Hong Ma, Sebastian Ribecky
///Coded by Hong Ma
///Email: hong.ma@tu-ilmenau.de
///2019.01.31, TU Ilmenau, Germany
///</summary>
using UnityEngine;

/// <summary>
/// Pause the game
/// </summary>
public class PauseBtn : MonoBehaviour {
    public void PauseBtnClicked(){
        SettingMenuController.Instance.IsGamePause = !SettingMenuController.Instance.IsGamePause;
    }
}
