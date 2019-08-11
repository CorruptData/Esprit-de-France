using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bakersword : MonoBehaviour
{
    float frames = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (frames >= 720 && frames < 730)
        {
            transform.position += new Vector3(0f, -7f / 10f, 0f);
        }
        frames += 1;
    }
}
