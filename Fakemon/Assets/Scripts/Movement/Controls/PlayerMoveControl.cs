using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveControl : MonoBehaviour {

	// Scripts

	Move move;

	public MonMoveControl monMoveControl;

	// Variables

	int cellSize = 1;

	private void Start () {

		// Scripts

		move = GetComponent<Move> ();
	}

	private void Update () {

		if (GotInputX ()) {
			
			if (!move.moving) {

				if (!HitWall (new Vector2 (InputDirectionX (), 0))) {
					
					move.shouldMoveX = true;

					NewTargetPositionX ();

					ComeHereMon ();
				}
			}

		} else if (GotInputY ()) {

			if (!move.moving) {

				if (!HitWall (new Vector2 (0, InputDirectionY ()))) {

					move.shouldMoveY = true;

					NewTargetPositionY ();

					ComeHereMon ();
				}
			}
		}
	}

	#region New Target Position ________________________________________________

	void NewTargetPositionX () {
		move.targetPosition = GetTargetPositionX ();
	}

	void NewTargetPositionY () {
		move.targetPosition = GetTargetPositionY ();
	}

	Vector2 GetTargetPositionX () {
		return new Vector2 (move.lastGridPosition.x + InputDirectionX (), move.lastGridPosition.y);
	}

	Vector2 GetTargetPositionY () {
		return new Vector2 (move.lastGridPosition.x, move.lastGridPosition.y + InputDirectionY ());
	}

	#endregion

	#region Inputs _____________________________________________________________

	bool GotInputX () {
		return Input.GetAxisRaw ("Horizontal") != 0;
	}

	bool GotInputY () {
		return Input.GetAxisRaw ("Vertical") != 0;
	}

	#endregion

	#region Direction __________________________________________________________

	int InputDirectionX () {
		return Input.GetAxisRaw ("Horizontal") > 0 ? cellSize : Input.GetAxisRaw ("Horizontal") < 0 ? -cellSize : 0;
	}

	int InputDirectionY () {
		return Input.GetAxisRaw ("Vertical") > 0 ? cellSize : Input.GetAxisRaw ("Vertical") < 0 ? -cellSize : 0;
	}

	#endregion

	#region Mon Control ________________________________________________________

	void ComeHereMon () {
		monMoveControl.FollowMaster (move.lastGridPosition, GotInputX (), GotInputY ());
	}

	#endregion

	#region Wall Finder ________________________________________________________

	bool HitWall (Vector2 direction) {

		bool hit = false;

		RaycastHit2D raycastHit = Physics2D.Raycast (transform.position, direction, cellSize);

		if (raycastHit) {
			hit = raycastHit.collider.tag == "Wall" ? true : false;
		}

		return hit;
	}

	#endregion
}
