using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public AudioClip shoot;

    // Start is called before the first frame update
    /*
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
    */
    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded && GetComponent<Rigidbody2D>().velocity.y <= 0)
            jump = true;
        

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
            Jump();
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);
        }

        Move( Input.GetAxis("Horizontal"));
        
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

}
