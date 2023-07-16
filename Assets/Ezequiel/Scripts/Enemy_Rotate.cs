using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Rotate : MonoBehaviour
{
    [SerializeField] AudioSource enemyAudio;
    [SerializeField] AudioClip deadAudio;
    private float _speedRotation = 5f;

    void Update()
    {
        Vector2 newWay = new Vector2(transform.position.x - 1, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, newWay, Manager.manager.worldSpeed * Time.deltaTime);
        transform.Rotate(0, 0, _speedRotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            enemyAudio.PlayOneShot(deadAudio, 1.0f);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Manager.manager.scorePoints += 150;

        }
    }
}
