using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{
    public static Rooms roomManager;

    
    public List<GameObject> lvlOne = new List<GameObject>();
    public List<GameObject> lvlTwo = new List<GameObject>();
    public List<GameObject> lvlThree = new List<GameObject>();

    public List<GameObject> GeneratedRooms = new List<GameObject>();
    public int openSide;
    private int rand;
    private bool spawned = false;
    public int limiteRooms = 3;



    private void Awake()
    {
        if (roomManager == null)
        {
            roomManager = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(roomManager);

        Invoke("Spawn", 0.1f);
    }

    public void Spawn()
    {
        if(!spawned && GeneratedRooms.Count <= limiteRooms)
        {
            
            


        }


/*
        if (!spawned && GeneratedRooms.Count <= limiteRooms)
        {
            if (openSide == 3)
            {
                rand = Random.Range(0, GameManager.gM.LeftRooms.Length);
                Instantiate(GameManager.gM.LeftRooms[rand], transform.position, GameManager.gM.LeftRooms[rand].transform.rotation);
            }
            else if (openSide == 4)
            {
                rand = Random.Range(0, GameManager.gM.RightRooms.Length);
                Instantiate(GameManager.gM.RightRooms[rand], transform.position, GameManager.gM.RightRooms[rand].transform.rotation);
            }
            spawned = true;
        }
*/
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        /*
        if (other.CompareTag("SpawnPoint"))
        {
            //Test -> 
            try
            {
                if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
                {
                    Instantiate(GameManager.gM.closedRoom, transform.position, GameManager.gM.closedRoom.transform.rotation);
                    Destroy(gameObject);
                }
                spawned = true;
            }
            catch (System.Exception)
            {
                Debug.Log("No hay nada que destruir");
            }
        }
*/
    }

}
