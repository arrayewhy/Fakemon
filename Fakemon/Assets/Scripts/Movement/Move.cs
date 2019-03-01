using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	// Components

	Transform _transform;

	// Scripts

	SpriteFlip spriteFlip;
	Direction direction;

	// Hooks

	[Header ("Control Hooks")]
	[Space (10)]
	public Vector2 lastGridPosition;
	public Vector2 targetPosition;

	public bool moving;

	public bool shouldMoveX;
	public bool shouldMoveY;

	public int moveSpeed = 5;

	// Enumerators

	IEnumerator checkMove;

	private void Start () {

		// Components

		_transform = transform;

		// Scripts

		spriteFlip = GetComponent<SpriteFlip> ();
		direction = GetComponent<Direction> ();

		#region Start Operations ...............................................

		checkMove = CheckMove ();
		StartCoroutine (checkMove);

		lastGridPosition = _transform.position;

		#endregion
	}

	IEnumerator CheckMove () {

		while (enabled) {

			if (moving) {

				if (DistanceFromTargetPositionX () > 0.1f) {

					CheckSpriteFlip ();

					_transform.Translate (MoveAmountX ());

				} else if (DistanceFromTargetPositionY () > 0.1f) {

					_transform.Translate (MoveAmountY ());

				} else {

					RoundPositionToInt ();

					lastGridPosition = _transform.position;

					if (shouldMoveX) shouldMoveX = false;
					else if (shouldMoveY) shouldMoveY = false;

					moving = false;
				}

			} else {

				if (shouldMoveX || shouldMoveY) {

					moving = true;

				}
			}

			yield return null;
		}
	}

	float DistanceFromTargetPositionX () {
		return Mathf.Abs (_transform.position.x - targetPosition.x);
	}

	float DistanceFromTargetPositionY () {
		return Mathf.Abs (_transform.position.y - targetPosition.y);
	}

	Vector2 MoveAmountX () {
		return new Vector2 (-(Mathf.Sign (lastGridPosition.x - targetPosition.x)), 0) * Time.deltaTime * moveSpeed;
	}

	Vector2 MoveAmountY () {
		return new Vector2 (0, -(Mathf.Sign (lastGridPosition.y - targetPosition.y))) * Time.deltaTime * moveSpeed;
	}

	#region Direction __________________________________________________________

	bool MovingRight () {
		return Mathf.Sign (-(_transform.position.x - targetPosition.x)) == 1;
	}

	bool MovingLeft () {
		return Mathf.Sign (-(_transform.position.x - targetPosition.x)) == -1;
	}

	#endregion

	#region Round Position To Int ______________________________________________

	void RoundPositionToInt () {
		_transform.position = new Vector2 (Mathf.RoundToInt (_transform.position.x), Mathf.RoundToInt (_transform.position.y));
	}

	#endregion

	#region Sprite Flip ________________________________________________________

	void CheckSpriteFlip () {
		if (ShouldFlipSprite ()) FlipSprite ();
	}

	bool ShouldFlipSprite () {
		return ShouldFaceRight () || ShouldFaceLeft ();
	}

	bool ShouldFaceRight () {
		return MovingRight () && !direction.facingRight;
	}

	bool ShouldFaceLeft () {
		return MovingLeft () && direction.facingRight;
	}

	void FlipSprite () {
		spriteFlip.FlipSprite (_transform);
		direction.facingRight = !direction.facingRight;
	}

	#endregion
}
