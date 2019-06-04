using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	// Components

	Transform _transform;

	// Scripts

	[Header ("Scripts:")]
	public ObstacleFinder obstacleFinder;

	// Movement Variables

	[Header ("Movement:")]
	public float moveSpeed = 2;

	// Hooks

	[Header ("Direction Input:")]
	public bool pressingUp;
	public bool pressingDown;
	public bool pressingLeft;
	public bool pressingRight;
	public float inputX;
	public float inputY;

	// Enumerators

	IEnumerator checkMove;

	private void Start ()
	{
		#region Initialisation .................................................

		// Components

		_transform = transform;

		#endregion

		#region Start Operations ...............................................

		checkMove = CheckMove ();
		StartCoroutine (checkMove);

		#endregion
	}

	IEnumerator CheckMove ()
	{
		while (enabled)
		{
			if (PressingUpDown (pressingUp, pressingDown))
			{
				if (!Blocked ())
				{
					MoveUpDown (Direction (inputY), moveSpeed);
				}
			}
			else if (PressingLeftRight (pressingLeft, pressingRight))
			{
				if (!Blocked ())
				{
					MoveLeftRight (Direction (inputX), moveSpeed);
				}
			}

			yield return null;
		}
	}

	#region Move _______________________________________________________________

	void MoveUpDown (float direction, float speed)
	{
		_transform.Translate (new Vector3 (0, direction * speed, 0) * Time.deltaTime);
	}

	void MoveLeftRight (float direction, float speed)
	{
		_transform.Translate (new Vector3 (direction * speed, 0, 0) * Time.deltaTime);
	}

	#endregion

	#region Direction __________________________________________________________

	float Direction (float input)
	{
		float output = input;

		if (output > 0)
		{
			output /= output;
		}
		else if (output < 0)
		{
			output /= -output;
		}

		return output;
	}

	#endregion

	#region Player Input _______________________________________________________

	bool PressingLeftRight (bool pressLeft, bool pressRight)
	{
		return pressLeft || pressRight;
	}

	bool PressingUpDown (bool pressUp, bool pressDown)
	{
		return pressUp || pressDown;
	}

	#endregion

	#region Obstacle Finder ____________________________________________________

	bool Blocked ()
	{
		obstacleFinder.FindObstacle ();

		return obstacleFinder.blocked;
	}

	#endregion
}
