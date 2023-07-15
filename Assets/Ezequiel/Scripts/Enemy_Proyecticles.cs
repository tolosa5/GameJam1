using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Proyecticles : MonoBehaviour
{
    private float _speed = 5f;
    private float _speedRotation = 1f;


    void Update()
    {
        Vector2 newWay = new Vector2(transform.position.x - 1, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, newWay, _speed * Time.deltaTime);
    }
}
