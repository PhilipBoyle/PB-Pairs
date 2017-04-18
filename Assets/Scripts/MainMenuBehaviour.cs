using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuBehaviour : MonoBehaviour {
    public void TriggerMenuBehaviour (int i)
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