using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{
    public int damage = 1;

    // Start is called before the first frame update


    void Update()
    {
        DoAI();
    }

    public abstract void DoAI();

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "player")
        {
            col.gameObject.GetComponent<Player>().Hurt(1, 1f);
        }
    }


    public void patrol()
    {
        bool runDir = facedRight;
        var rb = GetComponent<Rigidbody2D>();

        //RaycastHit2D hitWall = Physics2D.Raycast(new Vector2(rb.transform.position.x + ((runDir) ? 1f : -1f) * (rb.GetComponent<BoxCollider2D>().size.x), rb.transform.position.y), Vector2.down, 0.01f, (1 << 8), -Mathf.Infinity);

        RaycastHit2D hitGround = Physics2D.Raycast(new Vector2(rb.transform.position.x + ((runDir) ? 1f : -1f) * (4*rb.GetComponent<BoxCollider2D>().size.x), rb.transform.position.y + rb.GetComponent<BoxCollider2D>().size.y/2), Vector2.down, 0.3f, (1 << 8), -Mathf.Infinity);

        if (hitGround.collider == null)
        {
            runDir = !runDir;
        }

        Move(runDir ? 1 : -1);
    }
}
