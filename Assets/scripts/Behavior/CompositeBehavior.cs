using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flocking/Behavior/Composite")]
public class CompositeBehavior : FilterFlockingBehavior
{
    public override Vector2 CalculateMove(FlockingObejct flockingobejct, List<Transform> context, Flocking flock)
    {
        if (weights.Length != behaviors.Length)
        {
            return Vector2.zero;
        }

        Vector2 move = Vector2.zero;

        for (int i = 0; i < behaviors.Length; i++)
        {
            Vector2 partMove = behaviors[i].CalculateMove(flockingobejct, context, flock) * weights[i];

            if (partMove != Vector2.zero)
            {
                if (partMove.sqrMagnitude > weights[i] * weights[i])
                {
                    partMove.Normalize();
                    partMove *= weights[i];
                }
                move += partMove;
            }
        }
        return move;
    }



    public FlockingBehavior[] behaviors;
    public float[] weights;
}
