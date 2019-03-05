using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorState : MonoBehaviour
{
	// Components

	Animator animator;

	// Animator Hashes

	int busyHash = Animator.StringToHash ("Busy");

	private void Start ()
	{
		// Components

		animator = GetComponent<Animator> ();
	}

	#region Busy State _________________________________________________________

	public bool Busy ()
	{
		return animator.GetBool (busyHash);
	}

	public void BusyON ()
	{
		animator.SetBool (busyHash, true);
	}

	public void BusyOFF ()
	{
		animator.SetBool (busyHash, false);
	}

	#endregion
}
