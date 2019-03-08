using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit : MonoBehaviour
{
	// Scripts

    public SceneFade sceneFade;

	public IEnumerator ChangeScene (string targetScene)
	{
		bool exitSequenceComplete = false;

		while (!exitSequenceComplete)
		{
            // Hide Scene

            yield return sceneFade.HideScene ();

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
