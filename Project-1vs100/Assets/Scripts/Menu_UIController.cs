using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_UIController : MonoBehaviour
{
    //https://answers.unity.com/questions/994033/how-do-i-create-a-exitquit-button.html
    public void doExitGame()
    {
        Application.Quit();
         Debug.Log("Game is exiting");
    }
}
