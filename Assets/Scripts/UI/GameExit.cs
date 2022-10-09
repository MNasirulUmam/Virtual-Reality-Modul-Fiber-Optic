using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour
{
    public void ExitGames()
    {
        /*UnityEditor.EditorApplication.isPlaying = false;*/

        Application.Quit();

        Debug.Log("quit");
    }
}
