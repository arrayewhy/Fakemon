using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDirection : MonoBehaviour
{
	// Components

	SpriteRenderer spriteRenderer;

	// Scripts

	Direction direction;

	// Sprites

	[Header ("Sprites")]
	public Sprite up;
	public Sprite down;
	public Sprite side;

	// Variables

	public bool shouldLookSideWays;
	public bool shouldLookUp;

	private void Start ()
	{
		// Components

		spriteRenderer = GetComponent<SpriteRenderer> ();

		// Scripts

		direction = GetComponent<Direction> ();
	}

	private void Update ()
	{
		if (shouldLookSideWays)
		{
			if (ShouldFaceRight ()) LookRight ();
			else LookLeft ();
		}
		else
		{
			if (shouldLookUp) LookUp ();
			else LookDown ();
		}
	}

	#region Look _______________________________________________________________

	void LookLeft ()
	{
		if (spriteRenderer.sprite != side) spriteRenderer.sprite = side;
	}

	void LookRight ()
	{
		if (spriteRenderer.sprite != side) spriteRenderer.sprite = side;
	}

	void LookUp ()
	{
		if (spriteRenderer.sprite != up) spriteRenderer.sprite = up;
	}

	void LookDown ()
	{
		if (spriteRenderer.sprite != down) spriteRenderer.sprite = down;
	}

	#endregion

	#region Direction __________________________________________________________

	bool ShouldFaceRight ()
	{
		return direction.facingRight;
	}

	#endregion
}
