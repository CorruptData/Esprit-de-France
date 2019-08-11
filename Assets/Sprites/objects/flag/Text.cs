using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
    float frames = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((frames >= 600) && (frames < 660))
        {
            transform.localScale += new Vector3(0f, 1f/60f, 0f);
        }
        frames += 1;
    }
}
