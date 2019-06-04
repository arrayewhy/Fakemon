using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	// Scripts

	[Header ("Scripts:")]
	public PlayerInput playerInput;
	public Movement movement;

	// Enumerators

	IEnumerator updateDirectionInput;

	private void Start ()
	{
		#region Start Operations ...............................................

		updateDirectionInput = UpdateDirectionInput ();
		StartCoroutine (updateDirectionInput);

		#endregion
	}

	IEnumerator UpdateDirectionInput ()
	{
		while (enabled)
		{
			movement.pressingUp = playerInput.PressingUp ();
			movement.pressingDown = playerInput.PressingDown ();
			movement.pressingLeft = playerInput.PressingLeft ();
			movement.pressingRight = playerInput.PressingRight ();
			movement.inputX = playerInput.InputX ();
			movement.inputY = playerInput.InputY ();

			yield return null;
		}
	}
}
