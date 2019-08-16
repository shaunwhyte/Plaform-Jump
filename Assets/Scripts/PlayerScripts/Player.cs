using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public LifeManager lifeManager;
    Animator animator;

    float jumpVelocity = 40;

    float maxHeight = 0;
    public Scorer scorer;

    bool onGround = false;
    public Camera cam;

    public CameraMovement camMovement;
    public float ySpeed;

    bool invincible = false;
    public Color initialColor;
    // Use this for initialization
    void Start()
    {
        animator = gameObject.GetComponent<Animator>(); ;
        scorer = gameObject.GetComponent<Scorer>();
        rb = GetComponent<Rigidbody2D>();
        camMovement = cam.GetComponent(typeof(CameraMovement)) as CameraMovement;
        initialColor = GetComponent<Renderer>().material.color;
    }

    private void Awake()
    {
    }

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public float flashTime = 3.0f;


    Rigidbody2D rb;


    float horizonatalSpeed;
    string lastKey = "";
    private void Update()
    {

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        animator.speed = 1;

        ySpeed = rb.velocity.y;

        horizonatalSpeed = Input.GetAxis("Horizontal");

        if (horizonatalSpeed > 0 && onGround && !invincible)
        {
            animator.ResetTrigger("RunLeft");
            animator.SetTrigger("RunRight");
        }
        else if (horizonatalSpeed < 0 && onGround && !invincible)
        {
            animator.ResetTrigger("RunRight");
            animator.SetTrigger("RunLeft");
        }
        else if (onGround && !invincible)
        {
            animator.ResetTrigger("RunLeft");
            animator.ResetTrigger("RunRight");
            animator.SetTrigger("GoIdle");

        }

        this.transform.Translate(horizonatalSpeed * 0.55f * (Time.deltaTime * 60), 0, 0);

        if (Input.GetButtonDown("Jump") && onGround)
        {


            if ((Mathf.Abs(horizonatalSpeed) * 10) > 4)
            {
                rb.velocity = Vector2.up * (jumpVelocity + (Mathf.Abs(horizonatalSpeed) * 12));
            }
            else
            {
                rb.velocity = Vector2.up * (jumpVelocity);
            }

            onGround = false;
            if (!invincible)
            {
                animator.ResetTrigger("RunLeft");
                animator.ResetTrigger("RunRight");
                animator.ResetTrigger("GoIdle");
                animator.SetTrigger("Jump");
            }

        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "SideWall")
        {
        }

        if (collision.gameObject.tag == "fire")       //what holds the fire
        {
            takeLife();
            onGround = true;
        }
        else if (collision.gameObject.tag == "spikes")
        {
            Vector3 collisionDirection = (collision.gameObject.transform.position - gameObject.transform.position).normalized;
            if (collisionDirection.y < 0)
            {
                onGround = true;
                takeLife();

            }
        }
        else if (collision.gameObject.tag == "Platform")
        {
            Vector3 collisionDirection = (collision.gameObject.transform.position - gameObject.transform.position).normalized;
            if (collisionDirection.y < 0) onGround = true;
        }
        else if (collision.gameObject.tag == "freeheart")
        {
            Destroy(collision.gameObject);
            if (lifeManager.lifes < 3)
            {
                lifeManager.giveLife();
            }
            else
            {
                scorer.maxScore += 50;
            }
        }


    }


    public void kill()
    {
        SceneManager.LoadScene("Game"); //Load scene called Game
    }

    public void takeLife()
    {
        if (!invincible)
        {

            lifeManager.takeLife();
            invincible = true;
            animator.SetTrigger("hit");
            InvokeRepeating("FlashPlayer", flashTime, 440f);        //Restets invinibilty after the flashing
        }


    }


    void FlashPlayer()
    {
        animator.ResetTrigger("hit");
        animator.SetTrigger("GoIdle");
        CancelInvoke("FlashPlayer");
        invincible = false;
    }

}
