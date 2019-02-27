using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	// Components

	Transform _transform;

	// Move Variables

	public Vector2 gridPos;
	public Vector2 targPos;

	// Enumerators

	IEnumerator checkMove;

	private void Start () {

		// Components

		_transform = transform;

		#region Start Operations ...............................................

		checkMove = CheckMove ();
		StartCoroutine (checkMove);

		gridPos = _transform.position;

		#endregion
	}

	IEnumerator CheckMove () {

		bool moving = false;

		while (enabled) {

			if (moving) {
				
				if (Mathf.Abs (PositionV2 ().x - targPos.x) > 0.1f) {
					
					_transform.Translate (new Vector2 (-(Mathf.Sign (gridPos.x - targPos.x)), 0) * Time.deltaTime * 5);

				} else if (Mathf.Abs (PositionV2 ().y - targPos.y) > 0.1f) {

					_transform.Translate (new Vector2 (0, -(Mathf.Sign (gridPos.y - targPos.y))) * Time.deltaTime * 5);

				} else {

					_transform.position = new Vector2 (Mathf.RoundToInt (_transform.position.x), Mathf.RoundToInt (_transform.position.y));

					gridPos = targPos;

					moving = false;
				}

			} else {

				if (GotInputX ()) {

					targPos = new Vector2 (gridPos.x + DirectionX (), gridPos.y);

					moving = true;

				} else if (GotInputY ()) {

					targPos = new Vector2 (gridPos.x, gridPos.y + DirectionY ());

					moving = true;
				}
			}

			yield return null;
		}
	}

	Vector2 PositionV2 () {
		return new Vector2 (_transform.position.x, _transform.position.y);
	}

	bool GotInputX () {
		return Input.GetAxisRaw ("Horizontal") != 0;
	}

	bool GotInputY () {
		return Input.GetAxisRaw ("Vertical") != 0;
	}

	float DirectionX () {
		return Mathf.Sign (Input.GetAxisRaw ("Horizontal"));
	}

	float DirectionY () {
		return Mathf.Sign (Input.GetAxisRaw ("Vertical"));
	}
}
