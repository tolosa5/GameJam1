using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] Transform playerTransform;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(playerTransform.position.x 
            + 4, transform.position.y, transform.position.z), 10 * Time.deltaTime);
    }
}
