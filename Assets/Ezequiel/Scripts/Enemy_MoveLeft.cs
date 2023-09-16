using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_MoveLeft : MonoBehaviour
{
    [SerializeField] AudioSource enemyAudio;
    [SerializeField] AudioClip deadAudio;

    [SerializeField] GameObject texpuntos;

    void Update()
    {
        Vector2 newWay = new Vector2(transform.position.x - 1, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, newWay, Manager.manager.worldSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            enemyAudio.PlayOneShot(deadAudio, 1.0f);
            GameObject newpuntaje = Instantiate(texpuntos, gameObject.transform.position, Quaternion.identity);
            Destroy(newpuntaje, 1);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Manager.manager.scorePoints += 100;


        }
    }
}
