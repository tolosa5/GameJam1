using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvaManager : MonoBehaviour
{
    //[SerializeField] private Image menuPause;
    //public int[] selecScena;

    void Start()
    {

    }

    void Update()
    {

    }

    public void MenuReturn()
    {
        SceneManager.LoadScene("MenuReturn");
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void Pause()
    {
        Time.timeScale = 0;
        //gameObject.SetActive(true);

    }

    public void Continue()
    {
        //gameObject.SetActive(false);
        Time.timeScale = 1;

    }
}
