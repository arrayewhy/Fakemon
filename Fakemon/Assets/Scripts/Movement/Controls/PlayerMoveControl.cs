using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveControl : MonoBehaviour
{
    // Scripts

    Move move;
    ObstacleFinder obstacleFinder;
    AnimatorState animatorState;
    DoorHandler doorHandler;

    public MonMoveControl monMoveControl;
    public SceneEntry sceneEntry;

    // Move Variables

    int cellSize = 1;

    Collider2D obstacle;

    // Enumerators

    IEnumerator checkMove;

    private void Start ()
    {
        // Scripts

        move = GetComponent<Move> ();
        obstacleFinder = GetComponent<ObstacleFinder> ();
        animatorState = GetComponent<AnimatorState> ();
        doorHandler = GetComponent<DoorHandler> ();

        #region Start Operations ...............................................

        checkMove = CheckMove ();
        StartCoroutine (checkMove);

        #endregion
    }

    IEnumerator CheckMove ()
    {
        yield return InitializeScripts ();

		while (!sceneEntry.sceneReady) yield return null;

		while (enabled)
        {
            if (!Busy ())
            {
				if (GotInputX ())
                {
                    if (!move.moving)
                    {
                        DetectObstacleX ();

                        if (obstacle)
                        {
                            if (obstacle.tag == "Door")
                            {
                                InitiateMoveX ();

                                BusyON ();

                                while (move.moveX) yield return null;

                                CheckDoor ();
                            }
                        }
                        else InitiateMoveX ();
                    }
                }
                else if (GotInputY ())
                {
                    if (!move.moving)
                    {
                        DetectObstacleY ();

                        if (obstacle)
                        {
                            if (obstacle.tag == "Door")
                            {
                                InitiateMoveY ();

                                BusyON ();

                                while (move.moveY) yield return null;

                                CheckDoor ();
                            }
                        }
                        else InitiateMoveY ();
                    }
                }
            }

            yield return null;
        }
    }

    #region Initiate Move ______________________________________________________

    void InitiateMoveX ()
    {
        move.moveX = true;

        NewTargetPositionX ();

        ComeHereMon ();
    }

    void InitiateMoveY ()
    {
        move.moveY = true;

        NewTargetPositionY ();

        ComeHereMon ();
    }

    #endregion

    #region New Target Position ________________________________________________

    void NewTargetPositionX ()
    {
        move.targetPosition = GetTargetPositionX ();
    }

    void NewTargetPositionY ()
    {
        move.targetPosition = GetTargetPositionY ();
    }

    Vector2 GetTargetPositionX ()
    {
        return new Vector2 (move.lastGridPosition.x + InputDirectionX (), move.lastGridPosition.y);
    }

    Vector2 GetTargetPositionY ()
    {
        return new Vector2 (move.lastGridPosition.x, move.lastGridPosition.y + InputDirectionY ());
    }

    #endregion

    #region Inputs _____________________________________________________________

    bool GotInputX ()
    {
        return !Mathf.Approximately (Input.GetAxisRaw ("Horizontal"), 0);
    }

    bool GotInputY ()
    {
        return !Mathf.Approximately (Input.GetAxisRaw ("Vertical"), 0);
    }

    #endregion

    #region Direction __________________________________________________________

    int InputDirectionX ()
    {
        return Input.GetAxisRaw ("Horizontal") > 0 ? cellSize : Input.GetAxisRaw ("Horizontal") < 0 ? -cellSize : 0;
    }

    int InputDirectionY ()
    {
        return Input.GetAxisRaw ("Vertical") > 0 ? cellSize : Input.GetAxisRaw ("Vertical") < 0 ? -cellSize : 0;
    }

    #endregion

    #region Mon ________________________________________________________________

    void ComeHereMon ()
    {
        monMoveControl.FollowMaster (move.lastGridPosition, GotInputX (), GotInputY ());
    }

    string MonName ()
    {
        return "Bulbabro";
    }

    #endregion

    #region Record Obstacle ____________________________________________________

    void DetectObstacleX ()
    {
        obstacle = obstacleFinder.DetectObstacle (DetectionOriginX (), DetectionDirectionX (), DetectionDistance ());
    }

    void DetectObstacleY ()
    {
        obstacle = obstacleFinder.DetectObstacle (DetectionOriginY (), DetectionDirectionY (), DetectionDistance ());
    }

    Vector2 DetectionOriginX ()
    {
        return transform.position + new Vector3 (InputDirectionX () * cellSize, 0, 0);
    }

    Vector2 DetectionOriginY ()
    {
        return transform.position + new Vector3 (0, InputDirectionY () * cellSize, 0);
    }

    Vector2 DetectionDirectionX ()
    {
        return new Vector2 (InputDirectionX (), 0);
    }

    Vector2 DetectionDirectionY ()
    {
        return new Vector2 (0, InputDirectionY ());
    }

    int DetectionDistance ()
    {
        return cellSize / 2;
    }

    #endregion

    #region Door _______________________________________________________________

    void CheckDoor ()
    {
        doorHandler.CheckDoor (obstacle.gameObject);
    }

    #endregion

    #region Animator States ____________________________________________________

    bool Busy ()
    {
        return animatorState.Busy ();
    }

    void BusyON ()
    {
        animatorState.BusyON ();
    }

    #endregion

    #region Initialization _____________________________________________________

    // REFACTOR
    // Consider static instancing.

    IEnumerator InitializeScripts ()
    {
        InitializeSceneEntry ();

        yield return InitializeMonMoveControl ();
    }

    void InitializeSceneEntry ()
    {
        sceneEntry = !sceneEntry ? GameObject.Find ("Scene Manager").GetComponent<SceneEntry> () : sceneEntry;
    }

    IEnumerator InitializeMonMoveControl ()
    {
        GameObject mon = null;

        while (!monMoveControl)
        {
            mon = GameObject.Find (MonName ());

            if (mon)
            {
                monMoveControl = mon.GetComponent<MonMoveControl> ();
            }

            yield return null;
        }
    }

    #endregion
}
