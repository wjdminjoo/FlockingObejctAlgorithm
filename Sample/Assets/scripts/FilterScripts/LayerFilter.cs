using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flocking/Filter/LayerFilter")]
public class LayerFilter : Filter
{
    public override List<Transform> FilterList(FlockingObejct flockingobject, List<Transform> origin)
    {
        List<Transform> filtered = new List<Transform>();

        foreach (Transform item in origin)
        {
            if (mask == (mask | (1 << item.gameObject.layer))){
                filtered.Add(item);
            }
       }
        return filtered;
    }

    public LayerMask mask;
}
