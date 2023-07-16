using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvaManager : MonoBehaviour
{

    public void MenuReturn()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void RetryLevel()
    {
        switch(Manager.manager.actualLevel)
        {
            default:
            case 1:
                SceneLoad.LoadScene("Nivel1");    
                break;

            case 2:
                SceneLoad.LoadScene("Nivel2");
                break;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;


    }

    public void Continue()
    {
        Time.timeScale = 1;
    }
}
