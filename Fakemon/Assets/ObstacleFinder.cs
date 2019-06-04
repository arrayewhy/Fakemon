using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFinder : MonoBehaviour
{
	// Scripts

	[Header ("Scripts:")]
	public PlayerInput playerInput;

	// Obstacle Finder Variables

	[Header ("Finder Origin:")]
	public Transform origin;

	int layerMaskHash_Obstacle;

	// Hooks

	[Header ("Hooks:")]
	public bool blocked;

	private void Start ()
	{
		#region Initialisation .................................................

		layerMaskHash_Obstacle = LayerMask.GetMask ("Obstacle");

		#endregion
	}

	public void FindObstacle ()
	{
		if (Physics2D.Raycast (new Vector2 (origin.position.x, origin.position.y), SearchDirection (), 1, layerMaskHash_Obstacle))
		{
			blocked = true;
		}
		else
		{
			blocked = false;
		}
	}

	Vector2 SearchDirection ()
	{
		Vector2 direction = new Vector2 (0, 0);

		if (playerInput.PressingUp ())
		{
			direction.y = 1;
		}
		else if (playerInput.PressingDown ())
		{
			direction.y = -1;
		}
		else if (playerInput.PressingLeft ())
		{
			direction.x = -1;
		}
		else if (playerInput.PressingRight ())
		{
			direction.x = 1;
		}

		return direction;
	}
}
