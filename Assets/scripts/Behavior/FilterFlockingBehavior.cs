using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Flocking/Behavior/Alignment")]

public abstract class FilterFlockingBehavior : FlockingBehavior
{
   public Filter filter;
}
