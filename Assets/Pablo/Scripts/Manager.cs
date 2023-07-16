using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public GameObject[] goGameOver;
    public GameObject goNivel1HUD;
    public GameObject goNivel2HUD;
    private bool pauseActive = false;

    private int rand;

    public float scorePoints;
    public Text[] textScore;
    public Text textTotalScore;
    private int actualText = 0;


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
                Time.timeScale = 1f;
                actualText = 0;
                Destroy(Player.player.gameObject);
                Destroy(this.gameObject);
                Destroy(CameraPlayer.camPlayer.gameObject);
                break;
            case "Nivel1":
                goNivel1HUD.SetActive(true);
                goNivel2HUD.SetActive(false);

                break;
            
            case "Nivel2":
                Player.player.gameObject.SetActive(true);
                this.gameObject.SetActive(true);
                CameraPlayer.camPlayer.gameObject.SetActive(true);
                actualText++;
                Player.player.transform.position = new Vector3(-110f,0,0);
                Manager.manager.limiteRooms++;
                goNivel1HUD.SetActive(false);
                goNivel2HUD.SetActive(true);
                if(posStartGeneration == null)
                {
                    posStartGeneration = GameObject.Find("RoomsManager").GetComponent<Transform>();
                }


                OnStartLevel();
                break;
            case "Victory":

                Destroy(Player.player.gameObject);

                textTotalScore = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
                textTotalScore.text = "Total Score: " + (int)scorePoints;

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

        switch(actualLevel)
        {
            case 1:

                break;

            case 2:
                SceneManager.LoadScene("Nivel2");
                break;
            case 3:
                SceneManager.LoadScene("Victory");
                break;

        }
        
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
        if(actualText == 0)
        {
            goGameOver[actualText].SetActive(true);
            Time.timeScale = 0; 
        }
        else
        {
            goGameOver[actualText].SetActive(true);
            Time.timeScale = 0; 
        }
        

        
    }

    public void ScoreTime()
    {
        
        scorePoints += Time.deltaTime * 10;

        if(actualText==0)
        {
            textScore[actualText].text =  "Score: " + (int)scorePoints;
        }
        else
        {
            textScore[actualText].text = "" + (int)scorePoints;
        }


  

    }

}
