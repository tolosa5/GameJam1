using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] Transform playerTransform;

    private void Update()
    {
        //para que cuando se choque con pared que se lo lleve, la camara le deje
        if (!Player.player.CollisionDetection())
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(playerTransform.position.x 
                + 4, transform.position.y, transform.position.z), 15 * Time.deltaTime);

        }
    }
}
