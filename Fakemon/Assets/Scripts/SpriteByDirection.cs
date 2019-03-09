using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteByDirection : MonoBehaviour
{
	// Sprites

	[Header ("Sprites")]
	public Sprite up;
	public Sprite down;
	public Sprite side;

	#region Face Sprite ________________________________________________________

    public void FaceSprite_West (SpriteRenderer sr, out bool facing_Right, out bool lookingSideways)
	{
        SetSprite (sr, side);

        FlipSpriteX (sr);

        facing_Right = false;

        SidewaysON (out lookingSideways);
	}

    public void FaceSprite_East (SpriteRenderer sr, out bool facing_Right, out bool lookingSideways)
	{
        SetSprite (sr, side);

        FlipSpriteX (sr);

        facing_Right = true;

        SidewaysON (out lookingSideways);
	}

    public void FaceSprite_North (SpriteRenderer sr, out bool facing_Up, out bool lookingSideways)
	{
        SetSprite (sr, up);

        facing_Up = true;

        SidewaysOFF (out lookingSideways);
	}

    public void FaceSprite_South (SpriteRenderer sr, out bool facing_Up, out bool lookingSideways)
	{
        SetSprite (sr, down);

        facing_Up = false;

        SidewaysOFF (out lookingSideways);
	}

	#endregion

    #region Sprites ____________________________________________________________

    void SetSprite (SpriteRenderer sr, Sprite s)
    {
        sr.sprite = s;
    }

    void FlipSpriteX (SpriteRenderer sr)
    {
        sr.flipX = !sr.flipX;
    }

    #endregion

    #region Sideways ___________________________________________________________

    void SidewaysON (out bool lookingSideways)
    {
        lookingSideways = true;
    }

    void SidewaysOFF (out bool lookingSideways)
    {
        lookingSideways = false;
    }

    #endregion
}
