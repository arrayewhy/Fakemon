using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
	#region Direction __________________________________________________________

	public bool PressingLeft ()
	{
		return Input.GetAxisRaw ("Horizontal") < 0;
	}

	public bool PressingRight ()
	{
		return Input.GetAxisRaw ("Horizontal") > 0;
	}

	public bool PressingUp ()
	{
		return Input.GetAxisRaw ("Vertical") > 0;
	}

	public bool PressingDown ()
	{
		return Input.GetAxisRaw ("Vertical") < 0;
	}

	public float InputX ()
	{
		return Input.GetAxisRaw ("Horizontal");
	}

	public float InputY ()
	{
		return Input.GetAxisRaw ("Vertical");
	}

	#endregion

	#region Button _____________________________________________________________

	public bool PressingSubmit ()
	{
		return Input.GetButton ("Submit");
	}

	public bool PressingStart ()
	{
		return Input.GetButton ("Cancel");
	}

	#endregion
}
