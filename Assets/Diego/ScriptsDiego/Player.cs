using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum State {Fase1, Fase2}
    public State currentState;
    public static Player player;

    float h; //Inputs

    Rigidbody2D rb;
    SpriteRenderer sR;
    [SerializeField] Sprite[] playerSprites;

    #region Jump

    [SerializeField] float jumpForce;
    
    bool isJumping;
    bool isGrounded;
    [SerializeField] LayerMask isGround;
    [SerializeField] Transform playerFeet;

    #endregion



    #region Disparos

    float lastShoot;
    [SerializeField] float fireRate;

    [SerializeField] GameObject bullets;
    [SerializeField] Sprite[] bulletsSprite; //cambiar el sprite de las balas segun el nivel en el que se esta

    #endregion

    #region Dash

    float Gravity;

    TrailRenderer tr;

    [SerializeField] float dashCooldown = 2f;
    [SerializeField] float dashTime = 0.2f;
    [SerializeField] float dashForce;

    bool ableToDash = true;
    bool isDashing;
    bool dashed;

    Vector3 dashDir;

    #endregion

    #region Collision Detection

    [SerializeField] Transform checker;
    [SerializeField] float checkerSize;

    #endregion

    private void Awake()
    {
        if (player != null)
        {
            Destroy(gameObject);
        }
        else
        {
            player = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();
        tr = GetComponent<TrailRenderer>();

        Gravity = rb.gravityScale;
    }

    private void Update()
    {
        h = Input.GetAxisRaw("Horizontal");

        CollisionDetection();

        #region JumpCall

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            Jump();
        }
        #endregion

        #region FireCall

        lastShoot += Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.F) && lastShoot >= fireRate)
            Shoot();

        #endregion

        Debug.Log(dashCooldown);
        switch(currentState)
        {
            case State.Fase1:

            default:
            case State.Fase2:

                #region Dash
                if (ableToDash && h != 0)
                {
                    StartCoroutine(Dash());
                }
                #endregion

                #region BackFireCall

                if (Input.GetKeyDown(KeyCode.Q) && lastShoot >= fireRate)
                    StartCoroutine(BackShoot());
                #endregion

                break;
        }


        /*
        #region DashCall

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
            isDashing = true;
        #endregion
        */
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(playerFeet.position, 0.1f, isGround);
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void Shoot()
    {
        Instantiate(bullets, transform.position + Vector3.right * 1.5f, Quaternion.identity);
        lastShoot = 0;
    }

    IEnumerator BackShoot()
    {
        Debug.Log("disparopatra");
        sR.flipX = true;
        yield return new WaitForSeconds(.2f);
        Instantiate(bullets, transform.position + Vector3.left * 1.5f, Quaternion.identity);
        lastShoot = 0;
        yield return new WaitForSeconds(.2f);
        sR.flipX = false;
    }

    IEnumerator Dash()
    {
        ableToDash = false;
        isDashing = true;
        rb.gravityScale = 0f;
        tr.emitting = true;

        rb.velocity = new Vector3(h * dashForce, 0f);

        yield return new WaitForSeconds(dashTime);
        tr.emitting = false;
        rb.gravityScale = Gravity;
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        ableToDash = true;
    }

    public bool CollisionDetection()
    {
        bool activado = Physics2D.OverlapCircle(checker.position, checkerSize, isGround);
        return activado;
    }

    public void Death()
    {
        //si se mueve 11 bloques a la izquierda se ha muerto
    }
}
