using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flocking/Behavior/Alignment")]
public class AlignmentBehavior : FilterFlockingBehavior
{
    public override Vector2 CalculateMove(FlockingObejct flockingobejct, List<Transform> context, Flocking flock){
        if(context.Count == 0)
            return flockingobejct.transform.up;

        Vector2 alignment = Vector2.zero;
        List<Transform> filterContext = (filter == null) ? context : filter.FilterList(flockingobejct, context);
        foreach (Transform item in filterContext)
        {
            alignment += (Vector2)item.transform.up;
        }
        alignment /= context.Count;
        return alignment;
    }
}
