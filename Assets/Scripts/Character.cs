using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float runAccel = 1.0f;
    public float runCap = 1.0f;
    public float jumpSpeed = 1.0f;
    public float gravity = 0.5f;
    public int maxJumpFrames = 20;
    public int jumpFrames = 20;
    public int hp = 5;
    public int invulnTime = 48;
    protected int invulnFrames = 0;

    public AudioClip jumpSound;
    public AudioClip step;

    public float bulletSpeed = 2.0f;
    public GameObject bullet;


    protected float lastYPos = 0;

    protected bool hasControl = true;
    
    protected bool grounded = false;			// Whether or not the player is grounded.

    protected bool facedRight = true;
    protected Animator anim;
    protected SpriteRenderer sprender;

    // Start is called before the first frame update
    protected void Start()
    {
        sprender = gameObject.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    protected void FixedUpdate()
    {
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

    protected void Awake()
    {

    }

    protected void Jump()
    {
        AudioSource.PlayClipAtPoint(jumpSound, transform.position);

        GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpSpeed));

    }

    protected void Move(float h)
    {

        //anim.SetFloat("Speed", Mathf.Abs(h));
        if (h * GetComponent<Rigidbody2D>().velocity.x < runCap)
            GetComponent<Rigidbody2D>().AddForce(new Vector2(h, 0f) * runAccel);

        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > runCap)
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * runCap, GetComponent<Rigidbody2D>().velocity.y);

        if ((h > 0 && !facedRight) ||
            (h < 0 && facedRight))
            Flip();

        if (grounded && h != 0)
        {
            // Apply upward force if normal is not zero.
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1, 1 << 8);


            // If the sign does not math the direction help the player up the slope.
            if (hit && (Mathf.Sign(hit.normal.x) != Mathf.Sign(h)))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, (Mathf.Abs(hit.normal.x)) + GetComponent<Rigidbody2D>().velocity.y);
            }
        }
    }

    protected void Flip()
    {
        // Switch the way the player is labelled as facing.
        facedRight = !facedRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

    public void FirePrimary()
    {
        Weapon w = GetComponentInChildren<Weapon>();

        // player is facing right
        if (facedRight)
        {
            w.Primary(Weapon.Direction.right);
        }
        else
        {
            w.Primary(Weapon.Direction.left);
        }
    }

    public void FirePrimary(float dir)
    {
        Weapon w = GetComponentInChildren<Weapon>();

        // player is facing right
        w.Primary(dir);
    }

    public void FireSecondary()
    {
        Weapon w = GetComponentInChildren<Weapon>();

        // player is facing right
        if (facedRight)
        {
            w.Secondary(Weapon.Direction.right);
        }
        else
        {
            w.Secondary(Weapon.Direction.left);
        }
    }

    public void FireSecondary(float dir)
    {
        Weapon w = GetComponentInChildren<Weapon>();

        // player is facing right
        w.Secondary(dir);
    }

    public void Hurt(int damage, float knockback)
    {
        if (invulnFrames > invulnTime)
        {
            if (facedRight)
                GetComponent<Rigidbody2D>().AddForce(Vector2.left * knockback);
            else
                GetComponent<Rigidbody2D>().AddForce(Vector2.right * knockback);

            // oeuf.ogg
            invulnFrames = 0;
            hp -= damage;

            if (hp <= 0)
            {
                Die();
            }
        }
    }

    protected void Die()
    {
        Destroy(gameObject);
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ground")
        {
            grounded = true;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "ground")
        {
            grounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "ground")
        {
            grounded = false;
        }
    }
}
