using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_square : MonoBehaviour
{
    //private float _speed = 5f;
    public bool touchBullet;

    private Manager _manager;

    void Update()
    {
        Vector2 newWay = new Vector2(transform.position.x - 1, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, newWay, _manager.worldSpeed * Time.deltaTime);

        if (touchBullet)
        {
            Destroy(gameObject);

        }
    }

}
