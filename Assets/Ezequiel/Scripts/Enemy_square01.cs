using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_square01 : MonoBehaviour
{
    private float _speed = 5f;
    public float count = 0;
    int newDir = 0;

    void Start()
    {
    }
    private void Update()
    {
        count++;
        if (count == 2)
        {
            newDir = -3;

        }
        else if (count == 4)
        {
            newDir = 3;
            count = 0;
        }
    }

    void FixedUpdate()
    {
        Vector2 newWay = new Vector2(transform.position.x - 1, transform.position.y + newDir);
        transform.position = Vector2.MoveTowards(transform.position, newWay, _speed * Time.deltaTime);
    }
}
