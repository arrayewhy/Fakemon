using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFinder : MonoBehaviour
{
    // Layer Mask Hash

    int layerMaskHash_Obstacle;

    private void Start ()
    {
        // Layer Mask Hash

        layerMaskHash_Obstacle = LayerMask.GetMask ("Obstacle");
	}

    public Collider2D DetectObstacle (Vector2 origin, Vector2 direction, int checkDistance)
	{
        RaycastHit2D raycastHit = Physics2D.Raycast (origin, direction, checkDistance, layerMaskHash_Obstacle);

		return raycastHit ? raycastHit.collider : null;
	}
}
