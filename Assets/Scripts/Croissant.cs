using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Croissant : MonoBehaviour
{
    

    void Start()
    {
        // Destroy the rocket after 2 seconds
        Destroy(gameObject, 5);
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity -= new Vector2(1f/60f,0f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "enemy") || (col.tag == "player"))
        {
            col.gameObject.GetComponent<Character>().Hurt(1, 2f);

            //Destroy(gameObject);
        }

        else if (col.gameObject.tag != "player")
        {
            //Destroy(gameObject);
        }
    }
}
