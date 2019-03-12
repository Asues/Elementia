///<summary>
///Team Work for Game Development Project from MT Students
///Awais Khan, Cesar Quintero Arias, Hong Ma, Sebastian Ribecky
///Coded by Hong Ma
///Email: hong.ma@tu-ilmenau.de
///2019.01.31, TU Ilmenau, Germany
///</summary>
using UnityEngine;
using UnityEngine.UI;

// For Floating attack values
public class FloatingText : MonoBehaviour {

    public Animator animator;

    private void Start()
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length);
    }

    /// <summary>
    /// Create a floating text content
    /// </summary>
    /// <param name="text"></param>
    public void SetText(string text)
    {
        animator.GetComponent<Text>().text = text;
    }

}
