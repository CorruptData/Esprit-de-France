using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    float frames = 1;
    SpriteRenderer s;
    // Start is called before the first frame update
    void Start()
    {
        s = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (frames == 720)
            s.color = new Color(0,0,255);
        else if (frames == 727)
            s.color = new Color(255, 255, 255);
        else if (frames == 734)
            s.color = new Color(255, 0, 0);
        else if (frames == 741)
            s.color = new Color(0, 0, 255);
        else if (frames == 748)
            s.color = new Color(255, 255, 255);
        else if (frames == 755)
            s.color = new Color(255, 0, 0);
        else if (frames == 762)
            s.color = new Color(0,0,0);
        else if (frames > 762 && frames <= 772)
        {
            s.color += new Color(255f / 10f, 255f / 10f, 255f / 10f);
        }

            frames += 1;
    }
}
