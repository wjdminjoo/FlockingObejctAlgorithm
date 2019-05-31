using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Flocking/Behavior/StayBehavior")]
public class StayRadiusBehavior : FilterFlockingBehavior
{
    public override Vector2 CalculateMove(FlockingObejct flockingobejct, List<Transform> context, Flocking flock)
    {
        Vector2 centerOffset = center - (Vector2)flockingobejct.transform.position;
        float i = centerOffset.magnitude / radius;
        if (i < 0.9f)
        {
            return Vector2.zero;
        }
        return centerOffset * i * i;
    }


    public Vector2 center;
    public float radius = 15.0f;
}
