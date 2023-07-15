using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{

    public int openSide;
    private int rand;
    private bool spawned = false;


    private void Awake()
    {

    }

    void Start()
    {
        Invoke("Spawn", 0.1f);
    }

   
    public void Spawn()
    {
        if(!spawned && Manager.manager.GeneratedRooms.Count <= Manager.manager.limiteRooms)
        {
            switch (Manager.manager.actualLevel)
            {
                default:
                case 1:
                Debug.Log("Nivel 1 Etapa2");
                if (openSide == 1)
                {
                    Debug.Log("Generamos Habitacion");
                    rand = Random.Range(0, Manager.manager.lvlOne.Count);
                    Instantiate(Manager.manager.lvlOne[rand], transform.position, Manager.manager.lvlOne[rand].transform.rotation);
                    Manager.manager.lvlOne.RemoveAt(rand);
                }

                    break;

                case 2:
                Debug.Log("Nivel 2 Etapa2");


                    break;

                case 3:
                Debug.Log("Nivel 3 Etapa2");


                    break;



            }

            if (Manager.manager.GeneratedRooms.Count == Manager.manager.limiteRooms)
            {
                Instantiate(Manager.manager.goPortal, transform.position + new Vector3(8,-2f,0), Manager.manager.goPortal.transform.rotation);
            }
        
            spawned = true;
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
            try
            {
                if (other.GetComponent<Rooms>().spawned == false && spawned == false)
                {
                    Instantiate(Manager.manager.lvlOne[rand], transform.position, Manager.manager.lvlOne[rand].transform.rotation);
                    Destroy(gameObject);
                }
                spawned = true;
            }
            catch (System.Exception)
            {
                Debug.Log("No hay nada que destruir");
            }
        }



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
