using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRooms : MonoBehaviour
{


    void Start()
    {
        
        Manager.manager.GeneratedRooms.Add(this.gameObject);
        transform.parent = Manager.manager.posStartGeneration.transform;

    }


}
