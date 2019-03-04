using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveControl : MonoBehaviour {

	// Scripts

	Move move;
	ObstacleFinder obstacleFinder;
	AnimatorState animatorState;
	DoorHandler doorHandler;

	public MonMoveControl monMoveControl;

	Door door;

	// Move Variables

	int cellSize = 1;

	Collider2D obstacle;

	private void Start () {

		// Scripts

		move = GetComponent<Move> ();
		obstacleFinder = GetComponent<ObstacleFinder> ();
		animatorState = GetComponent<AnimatorState> ();
		doorHandler = GetComponent<DoorHandler> ();
	}

	private void Update () {

		if (!Busy ()) {

			if (GotInputX ()) {

				if (!move.moving) {

					RecordObstacleX ();

					if (obstacle) {

						if (obstacle.tag == "Door") {

							CheckDoor ();
						}

					} else {

						InitiateMoveX ();
					}
				}

			} else if (GotInputY ()) {

				if (!move.moving) {

					RecordObstacleY ();

					if (obstacle) {

						if (obstacle.tag == "Door") {

							CheckDoor ();
						}

					} else {

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

	#region Record Obstacle ____________________________________________________

	void RecordObstacleX () {
		obstacle = obstacleFinder.FindObstacle (new Vector2 (InputDirectionX (), 0), cellSize);
	}

	void RecordObstacleY () {
		obstacle = obstacleFinder.FindObstacle (new Vector2 (0, InputDirectionY ()), cellSize);
	}

	#endregion

	#region Door _______________________________________________________________

	void CheckDoor () {
		doorHandler.CheckDoor (obstacle.gameObject);
	}

	#endregion

	#region Animator States ____________________________________________________

	bool Busy () {
		return animatorState.Busy ();
	}

	#endregion
}
