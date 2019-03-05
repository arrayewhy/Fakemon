using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit : MonoBehaviour
{
	// Scripts

	public SpriteFade spriteFade_SceneFadeHandler;

	// Enumerators

	IEnumerator hideScene;

	public IEnumerator ChangeScene (string targetScene)
	{
		bool exitSequenceComplete = false;

		while (!exitSequenceComplete)
		{
			// Hide Scene

			if (!spriteFade_SceneFadeHandler) yield return null;

			hideScene = spriteFade_SceneFadeHandler.FadeAlphaToFull ();

			yield return hideScene;

			// Load Scene

			LoadScene (targetScene);

			exitSequenceComplete = true;

			yield return null;
		}
	}

	void LoadScene (string targetScene)
	{
		SceneManager.LoadScene (targetScene);
	}
}
