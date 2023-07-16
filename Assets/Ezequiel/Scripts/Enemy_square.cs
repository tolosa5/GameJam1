using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_square : MonoBehaviour
{
    private float _speed = 5f;
    public bool touchBullet;

    [SerializeField] AudioSource enemyAudio;
    [SerializeField] AudioClip deadAudio;

    private void Start()
    {
        
    }
    void Update()
    {
        Vector2 newWay = new Vector2(transform.position.x - 1, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, newWay, Manager.manager.worldSpeed * Time.deltaTime);

        if (touchBullet)
        {
            enemyAudio.PlayOneShot(deadAudio, 1.0f);

            Destroy(gameObject);
            Manager.manager.scorePoints += 100;
        }
    }

}
