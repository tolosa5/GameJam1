using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public Transform posStartGeneration;

    private int rand;


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


    private void OnStartLevel()
    {
        switch (actualLevel)
        {
            default:
            case 1:
                Debug.Log("Nivel 1");
                rand = Random.Range(0, lvlOne.Count);
                Instantiate(lvlOne[rand], transform.position, lvlOne[rand].transform.rotation);
                lvlOne.RemoveAt(rand);
                //actualLevel++;

                //Rooms.roomManager.Invoke("Spawn", 0.1f);
                break;

            case 2:
                Debug.Log("Nivel 2");
                rand = Random.Range(0, lvlTwo.Count);
                Instantiate(lvlTwo[rand], transform.position, lvlTwo[rand].transform.rotation);
                // actualLevel++;

                //  Rooms.roomManager.Invoke("Spawn", 0.1f);
                break;

            case 3:
                Debug.Log("Nivel 3");
                rand = Random.Range(0, lvlThree.Count);
                Instantiate(lvlThree[rand], transform.position, lvlThree[rand].transform.rotation);
                // actualLevel++;

                // Rooms.roomManager.Invoke("Spawn", 0.1f);
                break;
        }


    }

    private void OnEndLevel()
    {


    }

}
