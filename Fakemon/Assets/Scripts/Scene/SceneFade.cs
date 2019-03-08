using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFade : MonoBehaviour
{
    // Scripts

    SpriteFade spriteFade;

    private void Start ()
    {
        // Scripts

        spriteFade = GetComponent<SpriteFade> ();
    }

    public IEnumerator RevealScene ()
    {
        while (!spriteFade) yield return null;

        yield return spriteFade.Alpha_FromFullToZero ();
    }

    public IEnumerator HideScene ()
    {
        yield return spriteFade.Alpha_FromCurrentToFull ();
    }
}
