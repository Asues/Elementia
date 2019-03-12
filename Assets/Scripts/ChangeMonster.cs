///<summary>
///Team Work for Game Development Project from MT Students
///Awais Khan, Cesar Quintero Arias, Hong Ma, Sebastian Ribecky
///Coded by Hong Ma
///Email: hong.ma@tu-ilmenau.de
///2019.01.31, TU Ilmenau, Germany
///</summary>
using UnityEngine;
using UnityEngine.UI;

// change monster button
public class ChangeMonster : MonoBehaviour {

    public Text InformationText;
    public Button AttackBtn, ConformSelectionBtn;

    public void ChangeMonsterBtnPressed()
    {
        // if game is paused, do nothing
        if (SettingMenuController.Instance.IsGamePause)
            return;
        InformationText.text = "Choose Monster";

        // show the monster selection btn, and hide attack, change monster buttons
        AttackBtn.gameObject.SetActive(false);
        ConformSelectionBtn.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
