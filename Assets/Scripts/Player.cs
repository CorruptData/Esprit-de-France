using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
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
        //grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded && GetComponent<Rigidbody2D>().velocity.y <= 0)
            Jump();


        if (grounded && (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > 0.01f))
        {
            //anim.SetTrigger("shootWalk");
        }
        else
        {
            //anim.SetTrigger("shootIdle");
        }

        Move( Input.GetAxis("Horizontal"));
        
        if (Input.GetKeyDown(KeyCode.F))
            FirePrimary();
    }

}
