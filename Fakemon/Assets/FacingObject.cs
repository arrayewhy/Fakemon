using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingObject : MonoBehaviour {

	public string HitObjectTag (Vector2 direction, int checkDistance) {

		RaycastHit2D raycastHit = Physics2D.Raycast (transform.position, direction, checkDistance);

		return raycastHit ? raycastHit.collider.tag : null;
	}
}
