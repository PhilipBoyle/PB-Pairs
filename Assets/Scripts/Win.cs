using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class Win : MonoBehaviour {
    public void WinBehaviour(int i)
    {
        switch (i)
        {
            default:
            case (0):
                SceneManager.LoadScene("Game");
                break;
            case (1):
                Application.Quit();
                break;
        }
    }
}
