using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEntry : MonoBehaviour
{
	// Scripts

	public SpriteFade spriteFade_SceneFadeHandler;

    public SpawnPlayerAndMonOnStart spawnPlayerAndMon;

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
        while (!sceneReady)
		{
			// Spawn Player & Mon

			SpawnPlayerAndMon ();

			// Reveal Scene

			if (!spriteFade_SceneFadeHandler.spriteRenderer) yield return null;

			revealScene = spriteFade_SceneFadeHandler.FadeAlphaToZero ();
            yield return revealScene;

            sceneReady = true;

			yield return null;
		}
	}

	#region Spawn Player & Mon _________________________________________________

	void SpawnPlayerAndMon ()
	{
        spawnPlayerAndMon.Spawn ();
	}

	#endregion
}
