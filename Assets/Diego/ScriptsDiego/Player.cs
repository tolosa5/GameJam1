using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum State {Fase1, Fase2}
    public State currentState;
    public static Player player;

    Vector3 myPosition;

    float h; //Inputs

    Rigidbody2D rb;
    SpriteRenderer sR;
    [SerializeField] Sprite[] playerSprites;

    Queue<KeyCode> inputBuffer;

    [SerializeField] float deadHeight;

    #region Jump

    [SerializeField] float jumpForce;
    float coyoteTime;
    bool coyoteActivated;
    
    bool isJumping;
    bool isGrounded;
    [SerializeField] LayerMask isGround;
    [SerializeField] Transform playerFeet;
    [SerializeField] float feetRadius;

    #endregion

    #region Disparos

    float lastShoot;
    [SerializeField] float fireRate;

    [SerializeField] GameObject bulletsR, bulletsL;
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

    bool collisionActivated;

    bool beingDragged;
    float timeDragged;

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

        inputBuffer = new Queue<KeyCode>();

        Gravity = rb.gravityScale;
    }

    private void Update()
    {
        h = Input.GetAxisRaw("Horizontal");

        CollisionDetection();
        Jump();
        CoyoteCheck();

        #region CameraKill

        if (CollisionDetection())
        {
            if (!collisionActivated)
            {
                collisionActivated = true;
                myPosition = transform.position;
            }

            if (Vector3.Distance(myPosition, transform.position) >= 12)
            {
                Death();
            }
            else
            {
                collisionActivated = false;
            }
        }
        else
        {
            myPosition = Vector3.zero;
        }
        #endregion

        #region JumpCall

        if (Input.GetKeyDown(KeyCode.Space))
        {
            inputBuffer.Enqueue(KeyCode.Space);

            if (inputBuffer.Count > 0)
            {
                Invoke("EraseAction", 0.1f);
            }
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
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(playerFeet.position, feetRadius, isGround);

        if (inputBuffer.Count > 0)
        {
            if (inputBuffer.Peek() == KeyCode.Space)
            {
                if (isGrounded)
                {
                    //isJumping = true;
                    rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);

                    inputBuffer.Dequeue();
                }
                else 
                {
                    if ((coyoteTime <= 0.12f) && !coyoteActivated)
                    {
                        coyoteActivated = true;
                        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                    }
                }
            }
        }
    }

    void CoyoteCheck()
    {
        if (isGrounded)
        {
            coyoteTime = 0;
            coyoteActivated = false;
            //isJumping = false;
        }
        else
        {
            coyoteTime += Time.deltaTime;
            Debug.Log("falling");
            Fall();
        }
    }

    void EraseAction()
    {
        inputBuffer.Dequeue();
    }

    void Shoot()
    {
        Instantiate(bulletsR, transform.position + Vector3.right * 1.5f, Quaternion.identity);
        lastShoot = 0;
    }

    IEnumerator BackShoot()
    {
        Debug.Log("disparopatra");
        sR.flipX = true;
        yield return new WaitForSeconds(.2f);
        Instantiate(bulletsL, transform.position + Vector3.left * 1.5f, Quaternion.identity);
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

    public void DoubleJumpActivator()
    {

    }

    void Fall()
    {
        if (transform.position.y <= deadHeight)
        {
            Debug.Log("deadfall");
            Death();
        }
    }

    public void Death()
    {
        Manager.manager.EndGame();

        //si se mueve 11 bloques a la izquierda se ha muerto
    }
}
