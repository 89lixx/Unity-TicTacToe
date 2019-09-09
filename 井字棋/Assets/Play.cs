using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Play : MonoBehaviour
{
    public Texture2D bgimg;
    public Texture2D cha;
    public Texture2D quan;

    private int[,] squares = new int[3,3]; //represent choices of two players
    private bool playing = true; //judge whether the game is playing
    private bool turn = true;    //take turns to play

    private void Start()
    {
        Reset();
    }

    //reset the screen
    private void Reset()
    {
        playing = true;
        for(int i = 0; i < 3; ++ i)
        {
            for(int j = 0; j < 3; ++ j)
            {
                squares[i, j] = -1;
            }
        }
        GUI.enabled = true;
    }

    //check who is the winner
    //1 represent player 1 wins
    //0 represent played 2 wins
    //2 represent on one wins
    private int Check()
    {
        //check rows
        for(int i = 0; i < 3; ++ i)
        {
            if (squares[i, 0] != -1 && squares[i, 0] == squares[i, 1] && squares[i, 0] == squares[i, 2])
                return squares[i, 0];
        }

        //check column
        for(int i = 0; i < 3; ++ i)
        {
            if (squares[0, i] != -1 && squares[0, i] == squares[1, i] && squares[2, i] == squares[0, i])
                return squares[0, i];
        }

        //check cross line
        if(squares[1, 1] != -1)
        {
            if (squares[0, 0] == squares[1, 1] && squares[1, 1] == squares[2, 2] || squares[1, 1] == squares[0, 2] && squares[1, 1] == squares[2, 0])
                return squares[1, 1];
        }
        for(int i = 0; i < 3; ++ i)
        {
            for(int j = 0; j < 3; ++ j)
            {
                if (squares[i, j] == -1)
                    return -1;
            }
        }
        return 2;
    }

    private void OnGUI()
    {
        //setting of background
        GUIStyle bg = new GUIStyle();
        bg.normal.background = bgimg;
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "", bg);

        //nine buttons
        int height = 100;
        int width = 100;
        float y = 300;
        float x = Screen.width*0.5f - 170;

        //reset button
        if (GUI.Button(new Rect(Screen.width*0.5f-170,170, 100, 100), "Reset")) {
            Reset();
            return;
        }

        //back button
        if(GUI.Button(new Rect(Screen.width * 0.5f + 130, 170, 100, 100), "Back To Menu"))
        {
            Application.LoadLevel("Welcome");
        }


        GUIStyle st = new GUIStyle
        {
            fontSize = 50,
            fontStyle = FontStyle.Bold,
        };
        st.normal.textColor = Color.green;
        int winner = -2;

        for (int i = 0; i < 3; ++i)
        {
            for(int j = 0; j < 3; ++j)
            {
                if(GUI.Button(new Rect(x + i * (width+50) , y + j * (height+50), height, width), ""))
                {
                    if (playing)
                    {
                        squares[i, j] = turn ? 1 : 0;
                        turn = !turn;
                    }
                }
                else if(squares[i, j] == 1)
                {
                    GUI.Button(new Rect(x + i * (width + 50), y + j * (height + 50), height, width), quan);
                }
                else if(squares[i, j] == 0)
                {
                    GUI.Button(new Rect(x + i * (width + 50), y + j * (height + 50), height, width), cha);
                }
                winner = Check();
                if(winner == 1 || winner == 0)
                {
                    playing = !playing;
                    GUI.enabled = false;
                    string msg = (winner==1) ? "Player 1 wins" : "Player 2 wins";
                    GUI.Label(new Rect(Screen.width * 0.5f-130, 100, 100, 100), msg, st);
                }
                if(winner == 2)
                {
                    playing = !playing;
                    GUI.enabled = false;
                    //string msg = (winner == 1) ? "Player 1 wins" : "Player 2 wins";
                    GUI.Label(new Rect(Screen.width * 0.5f - 130, 100, 100, 100), "No one wins", st);
                }
            }
        }

        //enbale reset button
        GUI.enabled = true;
    }

}