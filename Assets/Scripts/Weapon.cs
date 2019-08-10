using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
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
