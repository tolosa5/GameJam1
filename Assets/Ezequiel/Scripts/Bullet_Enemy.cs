using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float lifetime;

    private void Update()
    {
        transform.Translate((Vector2.left * speed) * Time.deltaTime);
        lifetime -= Time.deltaTime;

        if (lifetime <= 0)
            Destroy(gameObject);
    }
}
