﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public int damage = 1;
    public float knockback = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "enemy")
        {
            col.gameObject.GetComponent<Enemy>().Hurt(1, 2f);
        }
    }
}

