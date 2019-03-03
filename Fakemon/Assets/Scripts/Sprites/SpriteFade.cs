using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFade : MonoBehaviour {

	// Components

	[HideInInspector]
	public SpriteRenderer spriteRenderer;

	// Sprite Fade Variables

	int zeroAlpha = 0;
	int fullAlpha = 1;
	float stepDelay = 0.1f;
	float changeAmount = 0.25f;

	private void Start () {

		// Components

		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	public IEnumerator FadeAlphaToZero () {
		
		float lastChangeTime = 0;

		while (spriteRenderer.color.a > zeroAlpha) {

			if (Time.time > lastChangeTime + stepDelay) {

				spriteRenderer.color -= new Color (0, 0, 0, changeAmount);

				lastChangeTime = Time.time;
			}

			yield return null;
		}
	}

	public IEnumerator FadeAlphaToFull () {

		float lastChangeTime = 0;

		while (spriteRenderer.color.a < fullAlpha) {

			if (Time.time > lastChangeTime + stepDelay) {

				spriteRenderer.color += new Color (0, 0, 0, changeAmount);

				lastChangeTime = Time.time;
			}

			yield return null;
		}
	}
}
