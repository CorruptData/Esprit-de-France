using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightProjectileGun : Weapon
{
    public GameObject bullet;
    public float bulletSpeed = 5f;
    public AudioClip sound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += 1;
    }

    public override void Primary(Direction dir)
    {
        if (cooldown > MAX_COOLDOWN_FRAMES)
        {
            cooldown = 0;
            //anim.SetTrigger("Shoot");
            AudioSource.PlayClipAtPoint(sound, transform.parent.position);

            // player is facing right
            if (dir == Direction.right)
            {
                Rigidbody2D bulletInstance = Instantiate(bullet, new Vector3(transform.parent.position.x + .3f, transform.parent.position.y, transform.parent.position.z - .2f), Quaternion.Euler(new Vector3(0f, -1f, 0))).GetComponent<Rigidbody2D>();
                bulletInstance.velocity = new Vector2(bulletSpeed, 0);
            }
            else
            {
                Rigidbody2D bulletInstance = Instantiate(bullet, 
                                                         new Vector3(transform.parent.position.x - .3f, 
                                                         transform.parent.position.y,
                                                         transform.parent.position.z - .2f), 
                                                         Quaternion.Euler(new Vector3(-0f, -1f, 180f))).GetComponent<Rigidbody2D>();

                bulletInstance.velocity = new Vector2(-bulletSpeed, 0);
            }
        }
    }

    public override void Primary(float dir) { }

    public override void Secondary(Direction dir)
    {

    }

    public override void Secondary(float dir) { }
}
