using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveControl : MonoBehaviour {

	// Scripts

	Move move;
	FacingObject facingObject;
	AnimatorState animatorState;
	DoorHandler doorHandler;

	public MonMoveControl monMoveControl;

	Door door;

	// Variables

	int cellSize = 1;

	private void Start () {

		// Scripts

		move = GetComponent<Move> ();
		facingObject = GetComponent<FacingObject> ();
		animatorState = GetComponent<AnimatorState> ();
		doorHandler = GetComponent<DoorHandler> ();
	}

	private void Update () {

		if (!Busy ()) {

			if (GotInputX ()) {

				if (!move.moving) {

					if (FacingDoorX ()) {

						CheckDoor ();

					} else if (!FacingWallX ()) {

						InitiateMoveX ();

					}
				}

			} else if (GotInputY ()) {

				if (!move.moving) {

					if (FacingDoorY ()) {

						CheckDoor ();

					} else if (!FacingWallY ()) {

						InitiateMoveY ();

					}
				}
			}
		}
	}

	#region Initiate Move ______________________________________________________

	void InitiateMoveX () {

		move.shouldMoveX = true;

		NewTargetPositionX ();

		ComeHereMon ();
	}

	void InitiateMoveY () {

		move.shouldMoveY = true;

		NewTargetPositionY ();

		ComeHereMon ();
	}

	#endregion

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
		return !Mathf.Approximately (Input.GetAxisRaw ("Horizontal"), 0);
	}

	bool GotInputY () {
		return !Mathf.Approximately (Input.GetAxisRaw ("Vertical"), 0);
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

	#region Facing Wall ________________________________________________________

	bool FacingWallX () {
		return facingObject.HitObjectTag (new Vector2 (InputDirectionX (), 0), cellSize) == "Wall";
	}

	bool FacingWallY () {
		return facingObject.HitObjectTag (new Vector2 (0, InputDirectionY ()), cellSize) == "Wall";
	}

	#endregion

	#region Door _______________________________________________________________

	bool FacingDoorX () {
		return facingObject.HitObjectTag (new Vector2 (InputDirectionX (), 0), cellSize) == "Door";
	}

	bool FacingDoorY () {
		return facingObject.HitObjectTag (new Vector2 (0, InputDirectionY ()), cellSize) == "Door";
	}

	void CheckDoor () {
		doorHandler.CheckDoor ();
	}

	#endregion

	#region Animator States ____________________________________________________

	bool Busy () {
		return animatorState.Busy ();
	}

	#endregion
}
