using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int MAX_COOLDOWN_FRAMES = 60;
    protected int cooldown = 0;

    public abstract void Primary(Direction dir);

    public abstract void Primary(float dir);

    public abstract void Secondary(Direction dir);

    public abstract void Secondary(float dir);

    public enum Direction
    {
        left,
        right
    }
}
