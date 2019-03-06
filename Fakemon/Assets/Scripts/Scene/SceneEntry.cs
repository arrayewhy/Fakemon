using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEntry : MonoBehaviour
{
	// Scripts

	public SpriteFade spriteFade_SceneFadeHandler;

	public Spawn spawn;

	// Scene Entry Variables

	public bool sceneReady;

	// Enumerators

	IEnumerator enterScene;

	IEnumerator revealScene;

	private void Start ()
	{
		#region Start Operations ...............................................

		enterScene = EnterScene ();
		StartCoroutine (enterScene);

		#endregion
	}

	IEnumerator EnterScene ()
	{
		bool entrySequenceComplete = false;

		while (!entrySequenceComplete)
		{
			// Spawn Player & Mon

			SpawnPlayerAndMon ();

			// Reveal Scene

			if (!spriteFade_SceneFadeHandler.spriteRenderer) yield return null;

			revealScene = spriteFade_SceneFadeHandler.FadeAlphaToZero ();
			yield return revealScene;

			entrySequenceComplete = true;

			yield return null;
		}

		ReleaseScene ();
	}

	#region Spawn Player & Mon _________________________________________________

	void SpawnPlayerAndMon ()
	{
		SpawnPlayer ();
		SpawnMon ();
	}

	void SpawnPlayer ()
	{
		spawn.SpawnPlayer (PlayerSpawnPosition ());
	}

	void SpawnMon ()
	{
		spawn.SpawnMon (MonSpawnPosition ());
	}

	Vector2 PlayerSpawnPosition ()
	{
		return DoorPosition ();
	}

	Vector2 MonSpawnPosition ()
	{
		return PlayerSpawnPosition ();
	}

	#endregion

	#region Door _______________________________________________________________

	Vector2 DoorPosition ()
	{
		Vector2 position = new Vector2 ();
		return position;
	}

	#endregion

	#region Entry Sequence Complete ____________________________________________

	void ReleaseScene ()
	{
		sceneReady = true;
	}

	#endregion
}
