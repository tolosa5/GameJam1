using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class Parallax_Eze : MonoBehaviour
{

    public float speed = 5f;
    private float lenght;
    private Vector2 startpos;
    public GameObject cam;

    private void Start()
    {
        startpos = transform.position;

        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    private void FixedUpdate()
    {
        float dist = cam.transform.position.x;

        //Vector2 newWay = new Vector2(transform.position.x - 1, transform.position.y);
        //transform.position = Vector2.MoveTowards(transform.position, newWay, speed * Time.deltaTime);

        //if (transform.position.x <= -120.5f)
        //{
        //    transform.position = new Vector3(lenght + startpos, transform.position.y, transform.position.z);

        //}
        if (Vector3.Distance(transform.position, startpos) >= lenght)
        {

        }
    }

    //private float startPos;
    //[SerializeField] Camera cam;
    //[SerializeField] private float parallaxEffectAmount;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    startPos = transform.position.x;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    float distance = (cam.transform.position.x * parallaxEffectAmount);
    //    transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    //}
}
