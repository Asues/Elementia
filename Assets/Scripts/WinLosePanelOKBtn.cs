///<summary>
///Team Work for Game Development Project from MT Students
///Awais Khan, Cesar Quintero Arias, Hong Ma, Sebastian Ribecky
///Coded by Hong Ma
///Email: hong.ma@tu-ilmenau.de
///2019.01.31, TU Ilmenau, Germany
///</summary>
using UnityEngine;

/// <summary>
/// Button function for game over
/// </summary>
public class WinLosePanelOKBtn : MonoBehaviour {

    // reload start menu
    public void OkBtnClicked()
    {
        Destroy(Camera.main.GetComponent<DonnotDestroy>());
        Destroy(Camera.main);
        PhotonNetwork.LoadLevel("00_BeginMenu");
    }
}
