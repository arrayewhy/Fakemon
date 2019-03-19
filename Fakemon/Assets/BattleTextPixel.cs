using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTextPixel : MonoBehaviour
{
    // Components

    Transform _transform;

    // Battle Text Variables

    Vector2 startPos;
    Vector2 outPos;
    float speed = 5;

    // Enumerator

    IEnumerator standyAnimation;

    private void Start ()
    {
        // Components

        _transform = transform;

        #region Start Operations ...............................................

        startPos = _transform.localPosition;
        outPos = new Vector2 (startPos.x + 20, startPos.y);

        _transform.localPosition = new Vector2 (startPos.x - 40, startPos.y);

        standyAnimation = StandbyAnimation ();
        StartCoroutine (standyAnimation);

        #endregion
    }

    IEnumerator StandbyAnimation ()
    {
        while (enabled)
        {
            while (!Input.GetButtonDown ("Submit")) yield return null;

            bool entryDone = false;
            bool outroDone = false;

            while (!entryDone)
            {
                if (Mathf.Abs (_transform.localPosition.x - startPos.x) > 0.001f)
                {
                    if (Mathf.Abs (_transform.localPosition.x - startPos.x) < 1f)
                    {
                        if (speed > 1) speed -= 1 * Time.deltaTime;
                    }

                    _transform.localPosition = Vector2.Lerp (_transform.localPosition, startPos, Time.deltaTime * speed);
                }
                else
                {
                    _transform.localPosition = startPos;

                    entryDone = true;
                }

                yield return null;
            }

            for (float timer = 1; timer > 0; timer -= Time.deltaTime) yield return null;

            while (!outroDone)
            {
                if (Mathf.Abs (_transform.localPosition.x - outPos.x) > 0.01f)
                {
                    if (speed < 5) speed += 0.1f * Time.deltaTime;

                    _transform.localPosition = Vector2.Lerp (_transform.localPosition, outPos, Time.deltaTime * speed);
                }
                else
                {
                    outroDone = true;
                }

                yield return null;
            }

            _transform.localPosition = new Vector2 (startPos.x - 40, startPos.y);

            speed = 5;

            entryDone = false;

            outroDone = false;

            yield return null;
        }
    }
}
