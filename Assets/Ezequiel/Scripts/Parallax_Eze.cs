using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class Parallax_Eze : MonoBehaviour
{

    //public float speed = 5f;
    //private float lenght;
    //private Vector2 startpos;
    //public GameObject cam;

    private void FixedUpdate()
    {

        Vector2 newWay = new Vector2(transform.position.x - 1, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, newWay, (Manager.manager.worldSpeed - 2f) * Time.deltaTime);
    }
        //    //if (transform.position.x <= -120.5f)
        //    //{
        //    //    transform.position = new Vector3(lenght + startpos, transform.position.y, transform.position.z);

        //    //}
        //    if (Vector3.Distance(transform.position, startpos) >= lenght)
        //    {

        //    }
        //}

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

        //[SerializeField] private Transform img1, img2;
        //private float distance;
        //Vector2 starPos;

        //private void Start()
        //{
        //    distance = Vector3.Distance(img1.position, img2.position);
        //    starPos = transform.position;
        //}
        //private void Update()
        //{
        //    transform.Translate(Vector2.left * 5 * Time.deltaTime);

        //    if (Vector3.Distance(starPos, transform.position) >= distance)
        //    {
        //        transform.position = starPos;
        //    }
        //}
    }
