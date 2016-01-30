///<summary>
/// Main Menu
/// Attached to main camera
///</sumary>
using UnityEngine;
using System.Collections;

public class Mainmenu : MonoBehaviour {

    public Texture backgroundTexture; 

    void OnGUI()
    {
        //Display our Background Texture
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

            }
}
