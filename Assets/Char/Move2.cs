using System;
using UnityEngine;
using System.Collections;
using Photon.Pun;

public class Move2 : MonoBehaviourPun
{
    public AudioClip footstepSound;
    public float speed = 8f;
    public float maxSpeed = 15f;
    public float jump = 20f;
    public float maxVerticalSpeed = 10f;
    [Header("Orientation")]
    public bool orientToDirection = false;

    public bool test = true;
    private AudioSource audioSource;
    public AudioClip landSound;
    public AudioClip jumpSound;
    private Vector2 movement, cachedDirection;
    private float moveHorizontal;
    private float moveVertical;
    private Rigidbody2D rb;
    private Animator anim;
    private bool jumping = false;
    public bool reallyFalling = false;
    private bool isRight = false;
    private bool canSoundLand = false;
    private float scaleX;
    public bool dead = false;
    private void Start()
    {
        scaleX = transform.localScale.x;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update gets called every frame
    void Update ()
    {
        if (!dead)
        {
            normalMine();
        }
        
    }

    private void normalMine()
    {
        if (Math.Abs(rb.velocity.y) > 5f && reallyFalling)
        {
            anim.SetBool("fall", true);
        }
        else
        {
            anim.SetBool("fall", false);
        }
        
        if (jumping && reallyFalling)
        {
            anim.SetBool("fall", true);
            canSoundLand = true;
        }

        
        if (Math.Abs(rb.velocity.x) > 1f)
        {
            anim.speed = Math.Abs(rb.velocity.x * 0.2f);
        }
        
        
    }


    // FixedUpdate is called every frame when the physics are calculated
    void FixedUpdate ()
    {
        if (!dead)
        {
            fixedMine();
        }
    }

    public void footStep()
    {
        audioSource.volume = 0.4f;
        audioSource.PlayOneShot(footstepSound);
    }
    private void fixedMine()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        movement = new Vector2(moveHorizontal, 0);
        if (Math.Abs(moveHorizontal) > 0.4f)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
            // movement.x = 0;
            // rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (moveHorizontal > 0)
        {
            isRight = true;
            transform.localScale = new Vector2(scaleX, transform.localScale.y);
        } else if (moveHorizontal < 0)
        {
            isRight = false;
            transform.localScale = new Vector2(-scaleX, transform.localScale.y);
        }
        else
        {
            if (isRight)
            {
                transform.localScale = new Vector2(scaleX, transform.localScale.y);
            }
            else
            {
                transform.localScale = new Vector2(-scaleX, transform.localScale.y);
            }
        }

        
        rb.AddForce(movement * speed * 10f);
        // rb.velocity += movement * speed * 10;
        // rb.velocity = (movement * speed * 10f);
        if (Input.GetKey("space"))
        {
            if (!jumping)
            {
                var dir = new Vector2(transform.up.x, transform.up.y).normalized;
                rb.AddForce(new Vector2(0, jump * 10f) * dir);
                jumping = true;
                audioSource.volume = 0.2f;
                audioSource.PlayOneShot(jumpSound);
            }
        }
        if (Math.Abs(rb.velocity.x) > maxSpeed)
        {
            if (rb.velocity.x > 0)
            {
                rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
            }
            else
            {
                
                rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
            }
        }
        
        if (Math.Abs(rb.velocity.y) > maxVerticalSpeed)
        {
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, maxVerticalSpeed);
            }
        }
    }
    public void die()
    {
        var checkPoints = GameObject.FindGameObjectsWithTag("checkPoint");
        foreach (var c in checkPoints)
        {
            if (c.GetComponent<checkPoint>().isActive())
            {
                rb.transform.position = c.transform.position;
                rb.velocity = Vector2.zero;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("ground") || other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("levitate")
        || other.gameObject.CompareTag("ladder"))
        {
            jumping = false;
            anim.SetBool("fall", false);
            anim.SetBool("swing", false);
            if (canSoundLand)
            {
                audioSource.volume = 0.2f;
                audioSource.PlayOneShot(landSound);
                canSoundLand = false;
            }
        }

        if (other.gameObject.CompareTag("smallBox"))
        {
            jumping = false;
            anim.SetBool("fall", false);
        }

        if (other.gameObject.CompareTag("death") || other.gameObject.CompareTag("saw"))
        {
            Debug.Log("DEAD");
            die();
        }
        if (other.gameObject.CompareTag("ladder"))
        {
            reallyFalling = false;
            anim.SetBool("fall", false);
            print("ladder");
        }

        if (other.gameObject.CompareTag("bigDeath"))
        {
            Destroy(GameObject.FindGameObjectWithTag("bigGear"));
            die();
        }
        if (other.gameObject.CompareTag("bigGear"))
        {
            Destroy(other.gameObject);
            die();
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ladder"))
        {
            reallyFalling = false;
            print("ladder");
        }
        
    }
    
    
    private void OnCollisionExit(Collision other)
    {    
        if (other.gameObject.CompareTag("ladder"))
        {
            reallyFalling = true;
        }
        
        if (other.gameObject.CompareTag("ground") || other.gameObject.CompareTag("Player"))
        {
            // anim.SetBool("fall", false);
        }
    }
}