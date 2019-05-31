using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlockingBehavior : ScriptableObject
{
    public abstract Vector2 CalculateMove(FlockingObejct flockingobject, List<Transform> context, Flocking flock);
}
