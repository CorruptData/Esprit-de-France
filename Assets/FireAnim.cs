using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnim : MonoBehaviour
{
    float shootTime = 0f;
    float totalTime = 1f;
    Sprite[] shoot;
    public Sprite spriteOrig;
    // Start is called before the first frame update
    void Start()
    {
        shoot = Resources.LoadAll<Sprite>("skeleshoot/");
    }

    private void Update()
    {
        shootTime += Time.deltaTime;
        if (shootTime < totalTime)
        {
            GetComponent<SpriteRenderer>().sprite = shoot[(int)((shootTime * shoot.Length) / totalTime)];
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = spriteOrig;
        }

    }

    public void onShoot()
    {
        shootTime = 0f;
    }
}
