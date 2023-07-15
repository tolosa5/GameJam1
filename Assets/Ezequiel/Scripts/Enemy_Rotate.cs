using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Rotate : MonoBehaviour
{
    private float _speed = 5f;
    private float _speedRotation = 5f;

    void Update()
    {
        Vector2 newWay = new Vector2(transform.position.x - 1, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, newWay, _speed * Time.deltaTime);
        transform.Rotate(0, 0, _speedRotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
