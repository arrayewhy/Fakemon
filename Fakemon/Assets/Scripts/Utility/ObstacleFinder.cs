using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFinder : MonoBehaviour
{
	public Collider2D FindObstacle (Vector2 direction, int checkDistance)
	{
		RaycastHit2D raycastHit = Physics2D.Raycast (transform.position, direction, checkDistance);

		return raycastHit ? raycastHit.collider : null;
	}
}
