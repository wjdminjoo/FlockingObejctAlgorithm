using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Filter : ScriptableObject
{
   public abstract List<Transform> FilterList(FlockingObejct flockingobject, List<Transform> origin);
}
