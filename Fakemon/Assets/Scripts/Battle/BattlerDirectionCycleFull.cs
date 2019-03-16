using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlerDirectionCycleFull : MonoBehaviour
{
    // Components

    SpriteRenderer spriteRenderer;

    // Scripts

    SpriteByDirection spriteByDirection;
    Direction direction;
    FinderDirection finderDirection;

    // Direction Cycle Variables

    float intervalDuration = 1;

    [Header ("Orientation")]
    public bool lookingSideways = true;

    [Header ("Hook:")]
    public bool shouldCycle = true;

    // Enumerators

    IEnumerator cycle;

    private void Start ()
    {
        // Components

        spriteRenderer = GetComponent<SpriteRenderer> ();

        // Scripts

        spriteByDirection = GetComponent<SpriteByDirection> ();
        direction = GetComponent<Direction> ();
        finderDirection = GetComponentInChildren<FinderDirection> ();

		// Component Checker

		ComponentChecker.RecordComponent ();

		#region Start Operations ...............................................

		cycle = Cycle ();
        StartCoroutine (cycle);

        #endregion
    }

    #region Cycle Direction ____________________________________________________

    IEnumerator Cycle ()
    {
        float timer = Time.time;

        while (shouldCycle)
        {
            if (Time.time > timer + intervalDuration)
            {
                ChangeSpriteDirection ();

                RotateFinder ();

                timer = Time.time;
            }

            yield return null;
        }
    }

    #endregion

    #region Sprite Direction ___________________________________________________

    void ChangeSpriteDirection ()
    {
        if (lookingSideways)
        {
            if (FacingLeft ()) FaceSprite_North ();
            else FaceSprite_South ();
        }
        else
        {
            if (FacingUp ()) FaceSprite_East ();
            else FaceSprite_West ();
        }
    }

    #endregion

    #region Finder _____________________________________________________________

    void RotateFinder ()
    {
        finderDirection.RotateClockwise ();
    }

    #endregion

    #region Look _______________________________________________________________

    void FaceSprite_West ()
    {
        spriteByDirection.FaceSprite_West (spriteRenderer, out direction.facingRight, out lookingSideways);
    }

    void FaceSprite_East ()
    {
        spriteByDirection.FaceSprite_East (spriteRenderer, out direction.facingRight, out lookingSideways);
    }

    void FaceSprite_North ()
    {
        spriteByDirection.FaceSprite_North (spriteRenderer, out direction.facingUp, out lookingSideways);
    }

    void FaceSprite_South ()
    {
        spriteByDirection.FaceSprite_South (spriteRenderer, out direction.facingUp, out lookingSideways);
    }

    #endregion

    #region Check Direction ____________________________________________________

    bool FacingLeft ()
    {
        return !direction.facingRight;
    }

    bool FacingUp ()
    {
        return direction.facingUp;
    }

    #endregion
}
