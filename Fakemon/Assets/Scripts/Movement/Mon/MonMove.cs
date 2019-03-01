using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonMove : MonoBehaviour {

	// Components

	Transform _transform;

	// Scripts

	SpriteFlip spriteFlip;
	Direction direction;

	// Move Variables

	Vector2 gridPos;
	Vector2 targPos;
	int moveSpeed = 5;

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

		gridPos = _transform.position;

		#endregion
	}

	IEnumerator CheckMove () {

		bool moving = false;

		while (enabled) {

			if (moving) {

				if (DistanceFromTargetPositionX () > 0.1f) {

					if (ShouldFlipSprite ()) FlipSprite ();

					_transform.Translate (MoveAmountX ());

				} else if (DistanceFromTargetPositionY () > 0.1f) {

					_transform.Translate (MoveAmountY ());

				} else {

					RoundPositionToInt ();

					gridPos = targPos;

					moving = false;
				}

			} else {

				if (GotInputX ()) {

					targPos = NewTargetPositionX ();

				} else if (GotInputY ()) {

					targPos = NewTargetPositionY ();
				}

				moving = true;
			}

			yield return null;
		}
	}

	Vector2 PositionV2 () {
		return new Vector2 (_transform.position.x, _transform.position.y);
	}

	float DistanceFromTargetPositionX () {
		return Mathf.Abs (PositionV2 ().x - targPos.x);
	}

	float DistanceFromTargetPositionY () {
		return Mathf.Abs (PositionV2 ().y - targPos.y);
	}

	Vector2 MoveAmountX () {
		return new Vector2 (-(Mathf.Sign (gridPos.x - targPos.x)), 0) * Time.deltaTime * moveSpeed;
	}

	Vector2 MoveAmountY () {
		return new Vector2 (0, -(Mathf.Sign (gridPos.y - targPos.y))) * Time.deltaTime * moveSpeed;
	}

	void RoundPositionToInt () {
		_transform.position = new Vector2 (Mathf.RoundToInt (_transform.position.x), Mathf.RoundToInt (_transform.position.y));
	}

	Vector2 NewTargetPositionX () {
		return new Vector2 (gridPos.x + InputDirectionX (), gridPos.y);
	}

	Vector2 NewTargetPositionY () {
		return new Vector2 (gridPos.x, gridPos.y + InputDirectionY ());
	}

	#region Inputs _____________________________________________________________

	bool GotInputX () {
		return Input.GetAxisRaw ("Horizontal") != 0;
	}

	bool GotInputY () {
		return Input.GetAxisRaw ("Vertical") != 0;
	}

	#endregion

	#region Direction __________________________________________________________

	float InputDirectionX () {
		return Mathf.Sign (Input.GetAxisRaw ("Horizontal"));
	}

	float InputDirectionY () {
		return Mathf.Sign (Input.GetAxisRaw ("Vertical"));
	}

	bool MovingRight () {
		return Mathf.Sign (-(PositionV2 ().x - targPos.x)) == 1;
	}

	bool MovingLeft () {
		return Mathf.Sign (-(PositionV2 ().x - targPos.x)) == -1;
	}

	bool MovingUp () {
		return Mathf.Sign (-(PositionV2 ().y - targPos.y)) == 1;
	}

	bool MovingDown () {
		return Mathf.Sign (-(PositionV2 ().y - targPos.y)) == -1;
	}

	#endregion

	#region Sprite Flip ________________________________________________________

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
