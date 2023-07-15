using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax_Eze : MonoBehaviour
{
    private float lenght, startpos;
    public GameObject cam;
    public float parallazEffect;

    void Start()
    {
        startpos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        float temp = (cam.transform.transform.position.x * (1 - parallazEffect));
        float dist = (cam.transform.position.x * parallazEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + lenght) startpos += lenght;
        else if (temp < startpos - lenght) startpos -= lenght;

    }

}
