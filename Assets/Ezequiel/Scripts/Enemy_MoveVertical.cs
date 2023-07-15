using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_MoveVertical : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    private Transform currentPoint;

    [SerializeField] private float _speed;


    void Start()
    {
        currentPoint = waypoints[0];
    }

    void Update()
    {
        if (currentPoint == waypoints[0])
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[0].position, _speed * Time.deltaTime);
            if (transform.position == waypoints[0].position)
            {
                currentPoint = waypoints[1];
            }
        }
        if (currentPoint == waypoints[1])
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[1].position, _speed * Time.deltaTime);
            if (transform.position == waypoints[1].position)
            {
                currentPoint = waypoints[0];
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            gameObject.GetComponentInParent<Enemy_square>().touchBullet = true;
            Destroy(collision.gameObject);

        }
    }
}
