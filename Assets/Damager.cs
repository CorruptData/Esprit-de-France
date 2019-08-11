using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "player")
        {
            col.gameObject.GetComponent<Player>().Hurt(1, 1f);
        }
    }
}
