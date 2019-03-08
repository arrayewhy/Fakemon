using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
	// Components

	Transform _transform;

	// Scripts

	Direction direction;

	// Move Variables

	[Header ("Control Hooks")]
	[Space (10)]
	public Vector2 lastGridPosition;
	public Vector2 targetPosition;
	public bool moving;
	public bool moveX;
	public bool moveY;
	public int moveSpeed = 5;

    //[HideInInspector]
    public bool positionedOnGrid = true;

	// Enumerators

	IEnumerator checkMove;

	private void Start ()
	{
		// Components

		_transform = transform;

		// Scripts

		direction = GetComponent<Direction> ();

		#region Start Operations ...............................................

		checkMove = CheckMove ();
		StartCoroutine (checkMove);

		lastGridPosition = _transform.position;

		#endregion
	}

	IEnumerator CheckMove ()
	{
		while (enabled)
		{
			if (moving)
			{
				if (DistanceFromTargetPositionX () > 0.1f)
				{
					CheckSpriteFlip ();

					_transform.Translate (MoveAmountX ());
				}
				else if (DistanceFromTargetPositionY () > 0.1f)
				{
					_transform.Translate (MoveAmountY ());
				}
				else
				{
					RoundPositionToInt ();

                    positionedOnGrid = true;

					lastGridPosition = _transform.position;

                    ResetMoveFlags ();

					moving = false;
				}
			}
			else
			{
				if (moveX || moveY)
				{
					moving = true;

                    positionedOnGrid = false;
				}
			}

			yield return null;
		}
	}

	float DistanceFromTargetPositionX ()
	{
		return Mathf.Abs (_transform.position.x - targetPosition.x);
	}

	float DistanceFromTargetPositionY ()
	{
		return Mathf.Abs (_transform.position.y - targetPosition.y);
	}

	Vector2 MoveAmountX ()
	{
		return new Vector2 (-(Mathf.Sign (lastGridPosition.x - targetPosition.x)), 0) * Time.deltaTime * moveSpeed;
	}

	Vector2 MoveAmountY ()
	{
		return new Vector2 (0, -(Mathf.Sign (lastGridPosition.y - targetPosition.y))) * Time.deltaTime * moveSpeed;
	}

	#region Direction __________________________________________________________

	bool MovingRight ()
	{
		return Mathf.Sign (-(_transform.position.x - targetPosition.x)) == 1;
	}

	bool MovingLeft ()
	{
		return Mathf.Sign (-(_transform.position.x - targetPosition.x)) == -1;
	}

	#endregion

    #region Reset Move Flags ___________________________________________________

    void ResetMoveFlags ()
    {
        if (moveX) moveX = false;
        else if (moveY) moveY = false;
    }

    #endregion

	#region Round Position To Int ______________________________________________

	void RoundPositionToInt ()
	{
		_transform.position = new Vector2 (Mathf.RoundToInt (_transform.position.x), Mathf.RoundToInt (_transform.position.y));
	}

	#endregion

	#region Sprite Flip ________________________________________________________

	void CheckSpriteFlip ()
	{
		if (ShouldFlipSprite ())
		{
			return;
		}
	}

	bool ShouldFlipSprite ()
	{
		return ShouldFaceRight () || ShouldFaceLeft ();
	}

	bool ShouldFaceRight ()
	{
		return MovingRight () && !direction.facingRight;
	}

	bool ShouldFaceLeft ()
	{
		return MovingLeft () && direction.facingRight;
	}

	#endregion
}
