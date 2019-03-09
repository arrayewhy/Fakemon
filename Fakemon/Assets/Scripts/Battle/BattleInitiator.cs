using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleInitiator : MonoBehaviour
{
	// Scripts

	FindObjectByTag findObjectByTag;

	public Emotes emotes;

	// Emote Variables

	int flashDuration = 1;

	// Enumerators

	IEnumerator standbyBattle;

	IEnumerator flashAlert;

	private void Start ()
	{
		// Scripts

		findObjectByTag = GetComponent<FindObjectByTag> ();

		#region Start Operations ...............................................

		standbyBattle = StandbyBattle ();
		StartCoroutine (standbyBattle);

		#endregion
	}

	#region Standby ____________________________________________________________

	IEnumerator StandbyBattle ()
	{
		while (!findObjectByTag.seeTarget) yield return null;

		InitiateBattle ();
	}

	#endregion

	#region Battle _____________________________________________________________

	void InitiateBattle ()
	{
		FlashAlert ();
	}

	#endregion

	#region Emote ______________________________________________________________

	void FlashAlert ()
	{
		flashAlert = emotes.FlashAlert (flashDuration);
		StartCoroutine (flashAlert);
	}

	#endregion
}
