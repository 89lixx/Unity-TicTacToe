using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class welcome : MonoBehaviour
{
    public Texture2D img;

    private void OnGUI()
    {
        float height = Screen.height * 0.5f;
        float width = Screen.width * 0.5f;

        //back ground
        GUIStyle bg = new GUIStyle();
        bg.normal.background = img;
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "", bg);


        GUIStyle st = new GUIStyle {
            fontSize = 50,
            fontStyle = FontStyle.Bold,
        };
        GUI.Label(new Rect(width-130, 50, height, width), "Tic Tac Toe", st);
        if(GUI.Button(new Rect(width - 90, 300, 200,100), "PLAYER  VS  PLAYER"))
        {

            Application.LoadLevel("PLAY");
        }
    }
}
