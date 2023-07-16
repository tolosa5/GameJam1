using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_MoveLeft : MonoBehaviour
{


    void Update()
    {
        Vector2 newWay = new Vector2(transform.position.x - 1, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, newWay, Manager.manager.worldSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Manager.manager.scorePoints += 100;


        }
    }
}
