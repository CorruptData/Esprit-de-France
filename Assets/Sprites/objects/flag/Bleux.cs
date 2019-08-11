using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleux : MonoBehaviour
{
    float frames = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (frames <= 480f)
        {
            transform.rotation = Quaternion.Euler(((3f * 360f) / (480f)) * frames,
                                                  ((3f * 360f) / (480f)) * frames,
                                                  ((3f * 360f) / (480f)) * frames);

            transform.localScale += new Vector3(1.125f / 480f, 1.6875f / 480f, .3f / 480f);
        }
        if (frames <= 600)
        {
            transform.position += new Vector3(3.5f / 600f, 3.5f / 600f, 0f);
        }
        frames += 1;
    }
}
