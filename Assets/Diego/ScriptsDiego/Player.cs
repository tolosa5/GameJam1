using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum State {Fase1, Fase2}
    public State currentState;

    #region Jump

    [SerializeField] float jumpForce;
    
    bool isJumping;
    bool isGrounded;
    [SerializeField] LayerMask isGround;
    [SerializeField] Transform playerFeet;

    #endregion

    float h,v; //Inputs

    Rigidbody2D rb;
    Sprite playerSprite;
    SpriteRenderer sR;

    Vector3 ProyectGravity;

    #region Disparos

    float lastShoot;
    [SerializeField] float fireRate;

    [SerializeField] GameObject bullets; 
    [SerializeField] Sprite[] bulletsSprite; //cambiar el sprite de las balas segun el nivel en el que se esta

    #endregion

    #region Dash

    float dashCooldown;
    [SerializeField] float dashForce;

    bool ableToDash = true;
    bool isDashing;
    bool dashed;

    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();

        ProyectGravity = Physics.gravity;
    }

    private void Update()
    {
        Debug.Log(dashCooldown);
        switch(currentState)
        {
            case State.Fase1:

            default:
            case State.Fase2:
                #region Dash

                if (isDashing)
                {
                    rb.velocity = new Vector3(rb.velocity.x, 0);
                    Debug.Log("dashing");
                    dashCooldown += Time.deltaTime;

                    if (!dashed)
                    {
                        dashed = true;
                        rb.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
                    }
                    if (dashCooldown < 0.5f)
                    {
                        Physics.gravity = Vector3.zero;
                    }
                    else if (dashCooldown >= 0.5f && dashCooldown < 2f)
                    {
                        Physics.gravity = ProyectGravity;
                    }
                    else if (dashCooldown >= 2f)
                    {
                        isDashing = false;
                        dashed = false;
                        dashCooldown = 0;
                    }
                }
                #endregion

                break;
        }
        #region JumpCall

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("salto normal");
            isJumping = true;
            Jump();
        }
        #endregion

        #region FireCall

        lastShoot += Time.deltaTime;
        Debug.Log(lastShoot);
        if (Input.GetKeyDown(KeyCode.F) && lastShoot >= fireRate)
            Shoot();
        #endregion

        #region DashCall

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
            isDashing = true;
        #endregion
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(playerFeet.position, 0.1f, isGround);
        if (isGrounded)
        {
            Debug.Log("salto");
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void Shoot()
    {
        Instantiate(bullets, transform.position + Vector3.right * 1f, Quaternion.identity);
        lastShoot = 0;
    }
}
