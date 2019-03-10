using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneFade : MonoBehaviour
{
    // Components

    SpriteRenderer spriteRenderer;

    // Scripts

    SpriteFade spriteFade;

    // Battle Flash Variables

    float fadeStepDelay = 0.05f;

    int zeroAlpha = 0;
    int fullAlpha = 1;

    private void Start ()
    {
        // Components

        spriteRenderer = GetComponent<SpriteRenderer> ();

        // Scripts

        spriteFade = GetComponent<SpriteFade> ();
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
