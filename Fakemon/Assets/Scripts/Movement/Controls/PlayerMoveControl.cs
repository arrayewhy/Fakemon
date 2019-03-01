using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveControl : MonoBehaviour {

	// Scripts

	Move move;

	public MonMoveControl monMoveControl;

	private void Start () {

		// Scripts

		move = GetComponent<Move> ();
	}

	private void Update () {

		if (GotInputX ()) {

			if (!move.moving) {

				move.shouldMoveX = true;

				NewTargetPositionX ();

				ComeHereMon ();
			}

		} else if (GotInputY ()) {

			if (!move.moving) {

				move.shouldMoveY = true;

				NewTargetPositionY ();

				ComeHereMon ();
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
		return Input.GetAxisRaw ("Horizontal") > 0 ? 1 : Input.GetAxisRaw ("Horizontal") < 0 ? -1 : 0;
	}

	int InputDirectionY () {
		return Input.GetAxisRaw ("Vertical") > 0 ? 1 : Input.GetAxisRaw ("Vertical") < 0 ? -1 : 0;
	}

	#endregion

	void ComeHereMon () {
		monMoveControl.FollowMaster (move.lastGridPosition, GotInputX (), GotInputY ());
	}
}
