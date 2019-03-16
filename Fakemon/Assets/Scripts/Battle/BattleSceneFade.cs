using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneFade : MonoBehaviour
{
    // Scripts

    SpriteFade spriteFade;

    // Battle Flash Variables

    float fadeStepDelay = 0.05f;

    private void Start ()
    {
        // Scripts

        spriteFade = GetComponent<SpriteFade> ();

		// Component Checker

		ComponentChecker.RecordComponent ();
    }

    public IEnumerator BattleFlash ()
    {
        // REFACTOR
        // Consider combining enumerators into single enumerator.

        yield return spriteFade.Alpha_FromZeroToFull (fadeStepDelay);

        for (float Timer = fadeStepDelay; Timer > 0; Timer -= Time.deltaTime) yield return null;

        yield return spriteFade.Alpha_FromCurrentToZero (fadeStepDelay);

        for (float Timer = fadeStepDelay; Timer > 0; Timer -= Time.deltaTime) yield return null;

        yield return spriteFade.Alpha_FromCurrentToFull (fadeStepDelay);

        for (float Timer = fadeStepDelay; Timer > 0; Timer -= Time.deltaTime) yield return null;

        yield return spriteFade.Alpha_FromCurrentToZero (fadeStepDelay);

        for (float Timer = fadeStepDelay; Timer > 0; Timer -= Time.deltaTime) yield return null;

        yield return spriteFade.Alpha_FromCurrentToFull (fadeStepDelay);
    }
}
