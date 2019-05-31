using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class FlockingObejct : MonoBehaviour
{
    private void Start()
    {
        objectCollider = GetComponent<Collider2D>();
    }

    public void Move(Vector2 vel)
    {
        transform.up = vel;
        transform.position += (Vector3)vel * Time.deltaTime;
    }
    public void Init(Flocking flocking)
    {
        objectFlocking = flocking;
    }

    public Flocking ObjectFlocking { get { return objectFlocking; } }

    public Collider2D ObjectCollider { get { return objectCollider; } }
    private Collider2D objectCollider;
    private Flocking objectFlocking;


}
