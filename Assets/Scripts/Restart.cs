using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class Restart : MonoBehaviour
{
    public void RestartBehaviour(int i)
    {
        switch (i)
        {
            default:
            case (0):
                SceneManager.LoadScene("Game");
                break;
            case (1):
                SceneManager.LoadScene("Home");
                break;
        }
    }
}
