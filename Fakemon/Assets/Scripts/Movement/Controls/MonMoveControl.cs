using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonMoveControl : MonoBehaviour
{
	// Scripts

	Move monMove;

	private void Start ()
	{
		// Scripts

		monMove = GetComponent<Move> ();

		// Component Checker

		ComponentChecker.RecordComponent ();
	}

	public void FollowMaster (Vector2 masterGridPos, bool moveX, bool moveY)
	{
		monMove.targetPosition = masterGridPos;
		monMove.moveX = moveX;
        monMove.moveY = moveY;
	}
}