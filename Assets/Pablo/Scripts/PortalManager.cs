using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    


    void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Contacto Player");
            Manager.manager.OnEndLevel();
        }


    }
}
