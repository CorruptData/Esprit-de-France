using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject quick1;
    public GameObject quick2;
    public GameObject quick3;
    
    public GameObject wine;

    int playerHealth = 0;
    Player pl;

    // Start is called before the first frame update
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
        playerHealth = pl.hp;
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = pl.hp;
        wine.transform.localScale = new Vector3(1, playerHealth / 10f, 1);
        wine.transform.localPosition = new Vector3(-215, 46f + (playerHealth * 2.5f), 1);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            
        }
    }
}
