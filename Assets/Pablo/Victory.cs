using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public Button goToMenu;

    void Start()
    {
        goToMenu.onClick.AddListener(delegate{SceneManager.LoadScene("Menu");});
    }


}
