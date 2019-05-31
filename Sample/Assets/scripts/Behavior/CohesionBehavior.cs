using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flocking/Behavior/Cohesion")]
public class CohesionBehavior : FilterFlockingBehavior
{
    public override Vector2 CalculateMove(FlockingObejct flockingobejct, List<Transform> context, Flocking flock){
        if(context.Count == 0)
            return Vector2.zero;

        Vector2 cohesion = Vector2.zero;
        List<Transform> filterContext = (filter == null) ? context : filter.FilterList(flockingobejct, context);
        foreach (Transform item in filterContext)
        {
            cohesion += (Vector2)item.position;
        }
        cohesion /= context.Count;

        cohesion -= (Vector2)flockingobejct.transform.position;
        return cohesion;
    }
}
