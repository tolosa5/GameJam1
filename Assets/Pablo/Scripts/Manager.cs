using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static Manager manager;


    public List<GameObject> lvlOne = new List<GameObject>();
    public List<GameObject> lvlTwo = new List<GameObject>();
    public List<GameObject> lvlThree = new List<GameObject>();
    public List<GameObject> GeneratedRooms = new List<GameObject>();
    public GameObject goPortal;

    public int limiteRooms = 3; 
    public int actualLevel = 1;   

    public float worldSpeed = 1f;
    public bool worldGenerated = false;
    public Transform posStartGeneration;
    public GameObject goPause;
    public GameObject goGameOver;
    private bool pauseActive = false;

    private int rand;

    public float scorePoints;


    private void Awake()
    {

        #region Singleton

        if(manager == null)
            manager = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(manager);

        #endregion

        OnStartLevel();


        
    }


    private void Update()
    {
        WorldMovement();
        ScoreTime();

        //PauseSystem();
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }



    void OnSceneLoaded(Scene sceneLoad, LoadSceneMode modoCarga)
    {
        switch(sceneLoad.name)
        {
            default:
            Debug.Log("Hola");
            break;
            case "Menu":
                Destroy(Player.player.gameObject);
                Destroy(this.gameObject);
                break;

        }

    }


    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }



    public void PauseSystem()
    {

        if(Input.GetKeyDown(KeyCode.Escape) && !pauseActive)
        {
            Debug.Log("Pausamos");
            Time.timeScale = 0;
            goPause.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            goPause.SetActive(false);
        }


    }

    public void OnStartLevel()
    {
        switch (actualLevel)
        {
            default:
            case 1:
                Debug.Log("Nivel 1");
                rand = Random.Range(0, lvlOne.Count);
                Instantiate(lvlOne[rand], transform.position, lvlOne[rand].transform.rotation);
                lvlOne.RemoveAt(rand);

                break;

            case 2:
                Debug.Log("Nivel 2");
                rand = Random.Range(0, lvlTwo.Count);
                Instantiate(lvlTwo[rand], transform.position, lvlTwo[rand].transform.rotation);
                lvlTwo.RemoveAt(rand);

                break;

            case 3:
                Debug.Log("Nivel 3");
                rand = Random.Range(0, lvlThree.Count);
                Instantiate(lvlThree[rand], transform.position, lvlThree[rand].transform.rotation);
                lvlThree.RemoveAt(rand);
                break;
        }


    }

    public void OnEndLevel()
    {
        Debug.Log("Cambio Escena");
        GeneratedRooms.Clear();
        SceneManager.LoadScene("Nivel2");
       // OnStartLevel();

    }


    public void WorldMovement()
    {
        if(worldGenerated)
        {
            posStartGeneration.transform.Translate(new Vector3(-worldSpeed,0,0) * Time.deltaTime);
        }

    }

    public void EndGame()
    {

        goGameOver.SetActive(true);

        
    }

    public void ScoreTime()
    {
        
        scorePoints += Time.deltaTime * 10;

    }

}
