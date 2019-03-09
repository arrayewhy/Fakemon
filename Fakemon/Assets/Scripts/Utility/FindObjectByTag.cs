using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObjectByTag : MonoBehaviour
{
	// Player Finder Variables

	[Header ("Looking for:")]
	public string targetTag;

	public bool seeTarget;

	// Enumerators

	IEnumerator lookForTarget;

	private void Start ()
	{
		#region Start Operations ...............................................

		lookForTarget = LookForTarget ();
		StartCoroutine (lookForTarget);

		#endregion
	}

	IEnumerator LookForTarget ()
	{
		while (!seeTarget) yield return null;

		EngageTarget ();
	}

	#region Engage _____________________________________________________________

	void EngageTarget ()
	{
		print ("Aha!");
	}

	#endregion

	#region On Triggers ________________________________________________________

	private void OnTriggerEnter2D (Collider2D collision)
	{
		if (collision.tag == targetTag) seeTarget = true;
	}

	#endregion
}
