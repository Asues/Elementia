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
/// Play or Stop to play the background music
/// </summary>
public class PlayMusicBtn : MonoBehaviour {

    bool triger;

    public void PlayMusicBtnClicked()
    {
        Button btn = GetComponent<Button>();
        Sprite playSprite = Resources.Load<Sprite>("Images/Icons/IconPlayMusic");
        Sprite pauseSprite = Resources.Load<Sprite>("Images/Icons/IconPauseMusic");
        AudioSource audioData = Camera.main.GetComponent<AudioSource>();

        if (triger)
        {
            audioData.Play();
            btn.image.sprite = pauseSprite;
        }
        else
        {
            audioData.Stop();
            btn.image.sprite = playSprite;
        }
        triger = !triger;
    }
}
