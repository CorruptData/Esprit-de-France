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
            patrol();
        }
    }


}
