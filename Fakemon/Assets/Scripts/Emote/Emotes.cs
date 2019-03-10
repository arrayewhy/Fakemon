using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emotes : MonoBehaviour
{
	// Components

	SpriteRenderer spriteRenderer;

	// Emote Variables

	public Sprite[] emotes;

	private void Start ()
	{
		// Components

		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	#region Flash Emote ________________________________________________________

	public IEnumerator FlashAlert (float duration)
	{
		AssignAlert ();

		for (float timer = duration; timer > 0; timer -= Time.deltaTime) yield return null;

		UnassignEmote ();
	}

    public IEnumerator FlashEvil (float duration)
    {
        AssignEvil ();

        for (float timer = duration; timer > 0; timer -= Time.deltaTime) yield return null;

        UnassignEmote ();
    }

	#endregion

	#region Assign Emote _______________________________________________________

	void AssignAlert ()
	{
		spriteRenderer.sprite = GetEmote ("Alert");
	}

    void AssignEvil ()
    {
        spriteRenderer.sprite = GetEmote ("Evil");
    }

	#endregion

	#region Unassign Emote _____________________________________________________

	void UnassignEmote ()
	{
		spriteRenderer.sprite = null;
	}

	#endregion

	#region Get Emote __________________________________________________________

	Sprite GetEmote (string emoteName)
	{
		Sprite emote = null;

		for (int i = 0; i < emotes.Length; i++)
			if (emotes[i].name == emoteName) return emotes[i];

		return emote;
	}

	#endregion
}
