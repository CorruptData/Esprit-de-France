using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerEnemy : Enemy
{
    public bool pursuePlayer;
    public float pursuePlayerRange;
    public override void DoAI()
    {
        if(pursuePlayer)
        {
            
        } else
        {
            ignorePlayerAI();
        }
    }

    public void ignorePlayerAI()
    {
        bool runDir = facedRight;
        var rb = GetComponent<Rigidbody2D>();




        RaycastHit2D hitWall = Physics2D.Raycast(new Vector2(rb.transform.position.x + ((runDir) ? 1f : -1f) * (rb.GetComponent<BoxCollider2D>().size.x), rb.transform.position.y), Vector2.down, 0.01f, (1 << 8), -Mathf.Infinity);

        RaycastHit2D hitGround = Physics2D.Raycast(new Vector2(rb.transform.position.x + ((runDir) ? 1f : -1f) * (2*rb.GetComponent<BoxCollider2D>().size.x), rb.transform.position.y + rb.GetComponent<BoxCollider2D>().size.y), Vector2.down, 1f, (1<<8), -Mathf.Infinity);

        if (hitGround.collider == null || hitWall.collider != null)
        {
            runDir = !runDir;
        }

        Move(runDir ? 1 : -1);
    }
}
