using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFade : MonoBehaviour
{
    // Scripts

    SpriteFade spriteFade;

	// Scene Fade Variables

	float fadeStepDelay = 0.1f;

    private void Start ()
    {
        // Scripts

        spriteFade = GetComponent<SpriteFade> ();
    }

    public IEnumerator RevealScene ()
    {
        while (!spriteFade) yield return null;

        yield return spriteFade.Alpha_FromFullToZero (fadeStepDelay);
    }

    public IEnumerator HideScene ()
    {
        yield return spriteFade.Alpha_FromCurrentToFull (fadeStepDelay);
    }
}
