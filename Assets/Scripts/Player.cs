using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float accelX = 0.0f;
    float accelY = 0.0f;

    float speedX = 0.0f;
    float speedY = 0.0f;
    SpriteRenderer sprender;
    Animator anim;

    public float runAccel = 1.0f;
    public float runCap = 1.0f;
    public float jumpSpeed = 1.0f;
    public float gravity = 0.5f;
    public int maxJumpFrames = 20;
    public int jumpFrames = 20;
    public int hp = 5;
    public int invulnTime = 48;
    private int invulnFrames = 0;

    public AudioClip jumpSound;
    public AudioClip shoot;
    public AudioClip step;

    public float bulletSpeed = 2.0f;
    public GameObject bullet;


    float lastYPos = 0;

    bool hasControl = true;

    private Transform groundCheck;          // A position marking where to check if the player is grounded.
    private bool grounded = false;			// Whether or not the player is grounded.

    bool facedRight = true;
    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        lastYPos = transform.position.y;
        sprender = gameObject.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Awake()
    {
        groundCheck = transform.Find("GroundChecker");
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded && GetComponent<Rigidbody2D>().velocity.y <= 0)
            jump = true;
        
        //transform.position += new Vector3(speedX, speedY, 0.0f);
        //GetComponent<Rigidbody2D>().gravityScale = gravity;

        float h = Input.GetAxis("Horizontal");
        
        //anim.SetFloat("Speed", Mathf.Abs(h));
        
        if (h * GetComponent<Rigidbody2D>().velocity.x < runCap)
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * runAccel);
        
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > runCap)
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * runCap, GetComponent<Rigidbody2D>().velocity.y);
        
        if (h > 0 && !facedRight)
            Flip();

        else if (h < 0 && facedRight)
            Flip();

        if (grounded && (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > 0.01f))
        {
            anim.SetTrigger("shootWalk");
        }
        else
        {
            anim.SetTrigger("shootIdle");
        }
        
        if (jump)
        {
            //anim.SetTrigger("Jump");
            
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);
            
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpSpeed));
            
            jump = false;
        }
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            //anim.SetTrigger("Shoot");
            AudioSource.PlayClipAtPoint(shoot, transform.position);
            
            // player is facing right
            if (facedRight)
            {
                Rigidbody2D bulletInstance = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z-.2f), Quaternion.Euler(new Vector3(0f, -1f, 0))).GetComponent<Rigidbody2D>();
                bulletInstance.velocity = new Vector2(bulletSpeed, 0);
            }
            else
            {
                Rigidbody2D bulletInstance = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z-.2f), Quaternion.Euler(new Vector3(-0f, -1f, 180f))).GetComponent<Rigidbody2D>();
                bulletInstance.velocity = new Vector2(-bulletSpeed, 0);
            }
        }
        if (invulnFrames < invulnTime)
        {
            if (invulnFrames % 2 == 0)
            {
                sprender.enabled = false;
            }
            else
            {
                sprender.enabled = true;
            }
        }
        invulnFrames += 1;
    }

    void NormalizeSlope()
    {
        // Attempt vertical normalization
        if (grounded)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 1f, 1 << LayerMask.NameToLayer("Ground"));

            if (hit.collider != null && Mathf.Abs(hit.normal.x) > 0.1f)
            {
                Rigidbody2D body = GetComponent<Rigidbody2D>();
                // Apply the opposite force against the slope force 
                // You will need to provide your own slopeFriction to stabalize movement
                body.velocity = new Vector2(body.velocity.x - (hit.normal.x * .5f), body.velocity.y);

                //Move Player up or down to compensate for the slope below them
                Vector3 pos = transform.position;
                pos.y += -hit.normal.x * Mathf.Abs(body.velocity.x) * Time.deltaTime * (body.velocity.x - hit.normal.x > 0 ? 1 : -1);
                transform.position = pos;
            }
        }
    }

    void Flip()
    {
        // Switch the way the player is labelled as facing.
        facedRight = !facedRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

    public void Hurt(int damage)
    {
        if (invulnFrames > invulnTime)
        {
            // oeuf.ogg
            invulnFrames = 0;
            hp -= damage;

            if (hp <= 0)
            {
                Die();
            }
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
