using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFinder : MonoBehaviour
{
    public Collider2D DetectObstacle (Vector2 origin, Vector2 direction, int checkDistance)
	{
        RaycastHit2D raycastHit = Physics2D.Raycast (origin, direction, checkDistance);

		return raycastHit ? raycastHit.collider : null;
	}
}
