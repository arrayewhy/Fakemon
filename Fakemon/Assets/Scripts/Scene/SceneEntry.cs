using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEntry : MonoBehaviour
{
	// Scripts

	public SpriteFade spriteFade_SceneFadeHandler;

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
			// Reveal Scene

			if (!spriteFade_SceneFadeHandler.spriteRenderer) yield return null;

			revealScene = spriteFade_SceneFadeHandler.FadeAlphaToZero ();
			yield return revealScene;

			entrySequenceComplete = true;

			yield return null;
		}

		ReleaseScene ();
	}

	void ReleaseScene ()
	{
		sceneReady = true;
	}
}
