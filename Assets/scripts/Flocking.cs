using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocking : MonoBehaviour
{
    private void Awake()
    {
        flockingobjects = new List<FlockingObejct>();
    }

    private void Start()
    {
        squreMaxSpeed = Maxspeed * Maxspeed;
        squreNeighborRadius = neighborRadius * neighborRadius;
        squreRadius = squreNeighborRadius * Radius * Radius;

        for (int i = 0; i < startCount; i++)
        {
            FlockingObejct newObject = Instantiate(flockingobjectPrefabs,
             Random.insideUnitCircle * startCount * objectdensity,
            Quaternion.Euler(Vector3.forward * Random.Range(0.0f, 360.0f)),
            transform);
            newObject.name = "flocking" + i;
            newObject.Init(this);
            flockingobjects.Add(newObject);
        }
    }

    private void Update()
    {
        foreach (FlockingObejct flockingobject in flockingobjects)
        {
            List<Transform> context = GetNearbyObjects(flockingobject);
            Vector2 move = behgavior.CalculateMove(flockingobject, context, this);
            move *= drive;
            if (move.sqrMagnitude > squreMaxSpeed)
            {
                move = move.normalized * Maxspeed;
            }
            flockingobject.Move(move);
        }
    }


    private List<Transform> GetNearbyObjects(FlockingObejct objects)
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextCollider = Physics2D.OverlapCircleAll(objects.transform.position, neighborRadius);
        foreach (Collider2D c in contextCollider)
        {
            if (c != objects.ObjectCollider)
            {
                context.Add(c.transform);
            }
        }
        return context;
    }






    [Range(0.0f, 1.0f)] public float Radius = 0.5f;
    [Range(1.0f, 10.0f)] public float neighborRadius = 2.0f;
    [Range(1.0f, 100.0f)] public float Maxspeed = 3.0f;
    [Range(1.0f, 100.0f)] public float drive = 10.0f;
    [Range(10, 100)] public int startCount = 50;
    public FlockingObejct flockingobjectPrefabs;
    public FlockingBehavior behgavior;
    private List<FlockingObejct> flockingobjects;
    private const float objectdensity = 0.1f;
    private float squreMaxSpeed;
    private float squreNeighborRadius;
    private float squreRadius;
    public float SqureRadius { get { return squreRadius; } }

}
