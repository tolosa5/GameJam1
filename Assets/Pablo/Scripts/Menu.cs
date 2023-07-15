using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public Button btnPlay;
    public Button btnExit;


    private void Start()
    {
        InitializeVariables();


    }


    public void InitializeVariables()
    {
        btnPlay.onClick.AddListener(delegate{SceneLoad.LoadScene("Nivel1");});
        btnExit.onClick.AddListener(delegate{Application.Quit(); Debug.Log("Exit Game");});


    }


}
