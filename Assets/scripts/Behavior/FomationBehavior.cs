using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flocking/Behavior/Formation")]
public class FomationBehavior : FilterFlockingBehavior
{
    public override Vector2 CalculateMove(FlockingObejct flockingobejct, List<Transform> context, Flocking flock){
        if(context.Count == 0)
            return Vector2.zero;

        Vector2 formation = Vector2.zero;
        List<Transform> filterContext = (filter == null) ? context : filter.FilterList(flockingobejct, context);
        foreach (Transform item in filterContext)
        {
            formation += new Vector2(Mathf.Sin(item.transform.position.x), Mathf.Cos(item.transform.position.y));
        }
        return formation;
    }
}
