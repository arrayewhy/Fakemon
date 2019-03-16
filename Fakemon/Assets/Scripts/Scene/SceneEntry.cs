using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEntry : MonoBehaviour
{
	// Scripts

    public SceneFade sceneFade;
    public SpawnPlayerAndMonOnStart spawnPlayerAndMon;

	// Scene Entry Variables

	public bool sceneReady;

	// Enumerators

	IEnumerator loadScene;

	private void Start ()
	{
		#region Start Operations ...............................................

		loadScene = LoadScene ();
		StartCoroutine (loadScene);

		#endregion
	}

	IEnumerator LoadScene ()
	{
		// Force Scene Black

		sceneFade.ForceSceneBlack ();

		// Proceed with Scene Loading

		while (!SceneReady ())
		{
			// Spawn Player & Mon

			SpawnPlayerAndMon ();

            // Reveal Scene

            yield return sceneFade.RevealScene ();

            // Release Scene

            ReleaseScene ();
		}
	}

	#region Spawn Player & Mon _________________________________________________

	void SpawnPlayerAndMon ()
	{
        spawnPlayerAndMon.Spawn ();
	}

	#endregion

    #region Scene Ready ________________________________________________________

    bool SceneReady ()
    {
        return sceneReady;
    }

    void ReleaseScene ()
    {
        sceneReady = true;
    }

    #endregion
}
