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
                    Debug.Log("Generamos Habitacion 1");
                    rand = Random.Range(0, Manager.manager.lvlOne.Count);
                    Instantiate(Manager.manager.lvlOne[rand], transform.position, Manager.manager.lvlOne[rand].transform.rotation);
                    Manager.manager.lvlOne.RemoveAt(rand);
                }

                    break;

                case 2:
                Debug.Log("Nivel 2 Etapa2");

                if (openSide == 1)
                {
                    Debug.Log("Generamos Habitacion 2");
                    rand = Random.Range(0, Manager.manager.lvlTwo.Count);
                    Instantiate(Manager.manager.lvlTwo[rand], transform.position, Manager.manager.lvlTwo[rand].transform.rotation);
                    Manager.manager.lvlTwo.RemoveAt(rand);
                }

                    break;

                case 3:
                Debug.Log("Nivel 3 Etapa2");

                if (openSide == 1)
                {
                    Debug.Log("Generamos Habitacion 3");
                    rand = Random.Range(0, Manager.manager.lvlThree.Count);
                    Instantiate(Manager.manager.lvlThree[rand], transform.position, Manager.manager.lvlThree[rand].transform.rotation);
                    Manager.manager.lvlThree.RemoveAt(rand);
                }

                    break;



            }

            if (Manager.manager.GeneratedRooms.Count == Manager.manager.limiteRooms)
            {
                GameObject goPortal = Instantiate(Manager.manager.goPortal, transform.position + new Vector3(110,0,0), Manager.manager.goPortal.transform.rotation);

                goPortal.transform.parent = Manager.manager.GeneratedRooms[Manager.manager.GeneratedRooms.Count - 1].transform;


                Manager.manager.worldGenerated = true;

                //-Temporal

                Manager.manager.actualLevel++;
                
                
                Debug.Log("End of Generate World");


            }
        
            spawned = true;
        }

    }


}
