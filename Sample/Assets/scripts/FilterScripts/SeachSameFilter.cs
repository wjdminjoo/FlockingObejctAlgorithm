using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flocking/Filter/SeachSame")]
public class SeachSameFilter : Filter
{
   public override List<Transform> FilterList(FlockingObejct flockingobject, List<Transform> origin){
       List<Transform> filtered = new List<Transform>();

       foreach(Transform item in origin){
           FlockingObejct itemObject = item.GetComponent<FlockingObejct>();
           if(itemObject != null && itemObject.ObjectFlocking == flockingobject.ObjectFlocking)
                filtered.Add(item);
       }
       return filtered;
   }
}
