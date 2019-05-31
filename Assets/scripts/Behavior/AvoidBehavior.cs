using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flocking/Behavior/Avoid")]
public class AvoidBehavior : FilterFlockingBehavior
{
    public override Vector2 CalculateMove(FlockingObejct flockingobject, List<Transform> context, Flocking flock)
    {
        if (context.Count == 0)
            return Vector2.zero;

        Vector2 avoid = Vector2.zero;
        int avoidnum = 0;
        List<Transform> filterContext = (filter == null) ? context : filter.FilterList(flockingobject, context);
        foreach (Transform item in filterContext)
        {
            if (Vector2.SqrMagnitude(item.position - flockingobject.transform.position) < flock.SqureRadius)
            {
                avoidnum++;
                avoid += (Vector2)(flockingobject.transform.position - item.position);
            }
        }
        if (avoidnum > 0)
            avoid /= avoidnum;
            
        return avoid;
    }
}
