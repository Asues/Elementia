///<summary>
///Team Work for Game Development Project from MT Students
///Awais Khan, Cesar Quintero Arias, Hong Ma, Sebastian Ribecky
///Coded by Hong Ma
///Email: hong.ma@tu-ilmenau.de
///2019.01.31, TU Ilmenau, Germany
///</summary>
using UnityEngine;

// create a floating attack values
public class FloatingTextController : MonoBehaviour {

    /// <summary>
    /// create a floating attack text
    /// </summary>
    /// <param name="monster">Monster, where the floating text should appear</param>
    /// <param name="value">content of the floating text</param>
    public static void CreateFloatingText (ElementiaMonster monster, string value)
    {
        GameObject canvas = GameObject.Find("Canvas");
        Transform location = GameObject.FindGameObjectWithTag(monster.Name).transform;

        // load the text prefab
        FloatingText popupText = Resources.Load<FloatingText>("Prefabs/PopupTextParent");

        // create a new clone of the prefab
        FloatingText instance = Instantiate(popupText);
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(location.position);
        instance.transform.SetParent(canvas.transform,true);
        instance.transform.position = screenPosition;
        instance.SetText(value);
    }
}
