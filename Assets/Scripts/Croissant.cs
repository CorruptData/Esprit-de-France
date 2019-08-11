using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Croissant : MonoBehaviour
{

    Rigidbody2D r;
    bool right = false;
    void Start()
    {
        r = GetComponent<Rigidbody2D>();

        // Destroy the rocket after 2 seconds
        Destroy(gameObject, 5);
    }
    private void Awake()
    {

        if (Mathf.Abs(r.velocity.x) > 0)
            right = true;
    }

    void Update()
    {
        r.velocity += new Vector2(((right ? -1f : 1f)*10f)/60f,0f);
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
