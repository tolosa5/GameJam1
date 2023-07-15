using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Parallax_Eze : MonoBehaviour
{

    private Manager _manager;
    public float speed = 5f;
    private float lenght, startpos;

    private void Start()
    {
        startpos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    private void FixedUpdate()
    {
        Vector2 newWay = new Vector2(transform.position.x - 1, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, newWay, speed * Time.deltaTime);

        if (transform.position.x <= -36.5f)
        {
            transform.position = new Vector3(173 + lenght, transform.position.y, transform.position.z);

        }
    }
}
