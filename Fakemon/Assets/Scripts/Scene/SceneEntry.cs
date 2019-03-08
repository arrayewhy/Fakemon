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

	IEnumerator enterScene;

	private void Start ()
	{
		#region Start Operations ...............................................

		enterScene = EnterScene ();
		StartCoroutine (enterScene);

		#endregion
	}

	IEnumerator EnterScene ()
	{
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
