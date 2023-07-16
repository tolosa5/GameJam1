using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{

   // [SerializeField] private Slider sliderLoading;
    public Button btnReadyToPlay;
    public Button btnReadyToPlay2;
    public GameObject nivel1;
    public GameObject nivel2;
    AsyncOperation operation;

    private bool loaded = false;
   
    private void Start()
    {
        loaded = false;
        string LoadLvL = SceneLoad.nextLVL;
        StartCoroutine(StartLoad(LoadLvL));
        btnReadyToPlay.onClick.AddListener(delegate
        {
            if(loaded)
            {
                operation.allowSceneActivation = true;
            }
        });
        btnReadyToPlay2.onClick.AddListener(delegate
        {
            if (loaded)
            {
                operation.allowSceneActivation = true;
            }
        });

        switch (LoadLvL)
        {
            default:
            case "Nivel1":

                nivel1.SetActive(true);

                break;
            
            case "Nivel2":

                nivel2.SetActive(true);



                break;

        }
    }

    IEnumerator StartLoad(string NextScene)
    {
        
        operation = SceneManager.LoadSceneAsync(NextScene);
        


        operation.allowSceneActivation = false;

        
        while (!operation.isDone)
        {

            if (operation.progress >= 0.9f)
            {
                loaded = true;
              //  btnReadyToPlay.gameObject.SetActive(true);
            }

            yield return null;
        }
    }
}
