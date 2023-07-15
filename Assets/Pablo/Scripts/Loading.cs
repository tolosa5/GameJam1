using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{

    //[SerializeField] private Slider sliderLoading;
    
    public Button btnReadyToPlay;
    private AsyncOperation operation;
    private bool loaded = false;

    private void Start()
    {
        string LoadLvL = SceneLoad.nextLVL;
        StartCoroutine(StartLoad(LoadLvL));
        btnReadyToPlay.onClick.AddListener(delegate
        {
            if(loaded)
            {
                operation.allowSceneActivation = true;
            }

        });
    }

    IEnumerator StartLoad(string NextScene)
    {
        yield return new WaitForSeconds(1f); //De momento esto para que dure la pantalla de carga
        
        operation = SceneManager.LoadSceneAsync(NextScene);
        
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {

            if (operation.progress >= 0.9f)
            {
                btnReadyToPlay.gameObject.SetActive(true);
                loaded = true;
            }

            yield return null;
        }
    }



}
