using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFade : MonoBehaviour
{
	// Components

	SpriteRenderer spriteRenderer;

    // Scripts

    SpriteFade spriteFade;

	// Scene Fade Variables

	float fadeStepDelay = 0.1f;

    private void Start ()
    {
		// Components

		spriteRenderer = GetComponent<SpriteRenderer> ();

        // Scripts

        spriteFade = GetComponent<SpriteFade> ();
	}

	// REFACTOR
	// Consider dedicated script for this function type.

	public void ForceSceneBlack ()
	{
		spriteRenderer.color += new Color (0, 0, 0, 1);
	}

	public IEnumerator RevealScene ()
    {
        while (!spriteFade) yield return null;

        yield return spriteFade.Alpha_FromCurrentToZero (fadeStepDelay);
    }

    public IEnumerator HideScene ()
    {
        yield return spriteFade.Alpha_FromCurrentToFull (fadeStepDelay);
    }
}
