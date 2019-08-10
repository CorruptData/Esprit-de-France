using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TricolourRocket : MonoBehaviour
{
    public GameObject explosion;
    
    void Start()
    {
        // Destroy the rocket after 2 seconds
        Destroy(gameObject, 2);
    }


    void OnExplode()
    {
        // Create a quaternion with a random rotation in the z-axis.
        Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 0f));
        
        Instantiate(explosion, transform.position, randomRotation);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "enemy")
        {
            col.gameObject.GetComponent<Enemy>().Hurt(1);
            
            OnExplode();
            
            Destroy(gameObject);
        }

        else if (col.gameObject.tag != "player")
        {
            OnExplode();
            Destroy(gameObject);
        }
    }
}