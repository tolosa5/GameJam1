using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    public static CameraPlayer camPlayer;

    private void Awake()
    {
        if (camPlayer != null)
        {
            Destroy(gameObject);
        }
        else
        {
            camPlayer = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        //para que cuando se choque con pared que se lo lleve, la camara le deje

        // CHOQUE PARED Estancar

        if (!Player.player.CollisionDetection())
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(playerTransform.position.x 
                + 4, transform.position.y, transform.position.z), 30 * Time.deltaTime);
        }
        else
        {
            transform.position = transform.position;
        }
    }
}
