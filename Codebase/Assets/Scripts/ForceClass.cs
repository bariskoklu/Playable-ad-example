using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ForceClass
{
    public enum ForceDirection
    {
        clockwise = -1,
        counterClockwise = 1
    }
    public float timeToApply;
    public float forceMagnitude;
    public ForceDirection forceDirection;
}
