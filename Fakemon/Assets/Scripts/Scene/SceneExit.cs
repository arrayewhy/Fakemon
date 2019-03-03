using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneExit : MonoBehaviour {

	// Scripts

	public SpriteFade spriteFade_SceneFadeHandler;

	// Enumerators

	IEnumerator exitScene;

	IEnumerator hideScene;

	public IEnumerator ExitScene () {

		bool exitSequenceComplete = false;

		while (!exitSequenceComplete) {

			// Hide Scene

			if (!spriteFade_SceneFadeHandler) yield return null;

			hideScene = spriteFade_SceneFadeHandler.FadeAlphaToFull ();

			yield return hideScene;

			exitSequenceComplete = true;

			yield return null;
		}
	}
}
