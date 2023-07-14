using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] float characterVelocity;

    [SerializeField] Transform playerFeet;
    [SerializeField] LayerMask isGround;

    bool jump;

    float h,v; //Inputs

    Rigidbody2D rb;
    Sprite playerSprite;
    SpriteRenderer sR;

    #region Disparos

    float lastShoot;
    float fireRate = 1f;

    [SerializeField] GameObject bullets; 
    [SerializeField] Sprite[] bulletsSprite; //cambiar el sprite de las balas segun el nivel en el que se esta

    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (jump)
        {
            Debug.Log("input salto");

            if (Physics2D.OverlapCircle(playerFeet.position, 0.1f, isGround))
            {
                Debug.Log("salto");
                Jump();
            }
            jump = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }

        lastShoot += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.F) && lastShoot >= fireRate)
            Shoot();
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
    }

    void Shoot()
    {
        Instantiate(bullets, transform.position + Vector3.right * 0.7f, Quaternion.identity);
    }
}
