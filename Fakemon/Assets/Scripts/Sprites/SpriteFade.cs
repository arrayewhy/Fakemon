﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFade : MonoBehaviour
{
	// Components

	[HideInInspector]
	public SpriteRenderer spriteRenderer;

	// Sprite Fade Variables

	int zeroAlpha = 0;
	int fullAlpha = 1;
	float stepDelay = 0.1f;
	float changeAmount = 0.25f;

	private void Start ()
	{
		// Components

		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	#region From Current Alpha _________________________________________________

    public IEnumerator Alpha_FromCurrentToZero ()
    {
        float lastChangeTime = 0;

        while (!Alpha_Zero ())
        {
            if (Time.time > lastChangeTime + stepDelay)
            {
                spriteRenderer.color -= new Color (0, 0, 0, changeAmount);

                lastChangeTime = Time.time;
            }

            yield return null;
        }
    }

    public IEnumerator Alpha_FromCurrentToFull ()
    {
        float lastChangeTime = 0;

        while (!Alpha_Full ())
        {
            if (Time.time > lastChangeTime + stepDelay)
            {
                spriteRenderer.color += new Color (0, 0, 0, changeAmount);

                lastChangeTime = Time.time;
            }

            yield return null;
        }
    }

    #endregion

    #region From Full Alpha ____________________________________________________

    public IEnumerator Alpha_FromFullToZero ()
    {
        spriteRenderer.color = new Color (spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, fullAlpha);

        float lastChangeTime = 0;

        while (!Alpha_Zero ())
        {
            if (Time.time > lastChangeTime + stepDelay)
            {
                spriteRenderer.color -= new Color (0, 0, 0, changeAmount);

                lastChangeTime = Time.time;
            }

            yield return null;
        }
    }

    #endregion

    #region Alpha Check ________________________________________________________

    bool Alpha_Zero ()
    {
        return spriteRenderer.color.a <= zeroAlpha;
    }

    bool Alpha_Full ()
    {
        return spriteRenderer.color.a >= fullAlpha;
    }

    #endregion
}
