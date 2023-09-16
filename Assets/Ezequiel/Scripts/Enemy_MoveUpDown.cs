using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_MoveUpDown : MonoBehaviour
{
    public float horizontalSpeed = 5f;
    public float verticalSpeed = 3f;
    public float amplitude = 2f;

    private float startingY;
    private float time = 0f;

    [SerializeField] AudioSource enemyAudio;
    [SerializeField] AudioClip deadAudio;

    private void Start()
    {
        startingY = transform.position.y;

    }

    void Update()
    {
        // Mover el objeto horizontalmente hacia la izquierda
        transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime);

        //testeo
        //transform.Translate(Vector3.left * Manager.manager.worldSpeed * Time.deltaTime);
        //

        // Hacer que el objeto suba y baje en un patrón sinusoidal
        time += Time.deltaTime * verticalSpeed;
        float newY = startingY + Mathf.Sin(time) * amplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            enemyAudio.PlayOneShot(deadAudio, 1.0f);
            Destroy(gameObject);
            Manager.manager.scorePoints += 100;
        }
    }
}
