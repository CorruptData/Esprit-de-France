using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerEnemy : Enemy
{
    public float pursuePlayerRange;
    bool aggro;
    public float yTolerance;

    public FireAnim f;

    public float JUMP_COOLDOWN_MAX = 2f;
    public float jumpCooldown = 0f;


    public float TEMP_FIRE_COOLDOWN_MAX = 4f;
    public float TEMP_FIRE_COOLDOWN = 0;


    public float FIREAIMTIMEMAX = 1.5f;
    public float fireaimtime = -1f;

    public override void DoAI()
    {
        aggro = Vector2.Distance(GameObject.FindGameObjectWithTag("player").transform.position, this.transform.position) < pursuePlayerRange;

        if (aggro)
        {
            fightPlayer();
        }
        else
        {
            patrol();
        }
    }

    public void fightPlayer()
    {
        //bullet make
        if(fireaimtime > 0 && (fireaimtime - Time.deltaTime < 0))
        {
            FirePrimary();
        }

        fireaimtime -= Time.deltaTime;
        jumpCooldown -= Time.deltaTime;
        TEMP_FIRE_COOLDOWN -= Time.deltaTime;

        // face player if we arent.
        bool playerDir = GameObject.FindGameObjectWithTag("player").transform.position.x > this.transform.position.x;
        if(facedRight != playerDir)
        {
            Move(facedRight ? -1 : 1);
        } else
        {
            // we are facing player. Now, see if we are on the same Y plane.
            float ydiff = GameObject.FindGameObjectWithTag("player").transform.position.y - this.transform.position.y;

            if (Mathf.Abs(ydiff) < yTolerance)
            {
                if (TEMP_FIRE_COOLDOWN < 0)
                {
                    dofire();
                }
            } else
            {
                if (ydiff > 0 && jumpCooldown < 0)
                {
                    jumpCooldown = JUMP_COOLDOWN_MAX;
                    // Jump to get into position. 
                    Jump();
                }
            }
        }
        
    }

    public void dofire()
    {
        Debug.Log("dofire");
        TEMP_FIRE_COOLDOWN = TEMP_FIRE_COOLDOWN_MAX;
        // Can shoot player.
        f.onShoot();
        fireaimtime = FIREAIMTIMEMAX;
    }


}
